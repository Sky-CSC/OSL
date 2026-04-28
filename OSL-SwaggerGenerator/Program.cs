using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Microsoft.OpenApi.Any;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

string swaggerPath = @"swagger.json"; // Chemin vers ton fichier Swagger
string targetEndpoint = "/lol-gameflow/v1/gameflow-phase"; // Endpoint ciblé
Console.WriteLine("Please enter the endpoint to be generated");
targetEndpoint = Console.ReadLine();
string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "GeneratedModels");
string targetNamespace = "OSL.Generated.Models";

Directory.CreateDirectory(outputDir);

var stream = File.OpenRead(swaggerPath);
var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

if (!document.Paths.TryGetValue(targetEndpoint, out var pathItem))
{
    Console.WriteLine($"❌ Endpoint '{targetEndpoint}' untraceable in swagger.");
    return;
}

var allRefs = new HashSet<string>();

// Collecte des schémas référencés par les réponses de l'endpoint
foreach (var operation in pathItem.Operations.Values)
{
    foreach (var response in operation.Responses.Values)
    {
        if (response.Content == null) continue;
        foreach (var mediaType in response.Content.Values)
        {
            if (mediaType.Schema != null)
                CollectSchemaRefs(mediaType.Schema, allRefs, document);
        }
    }
}

// Tracking des enums déjà générés
var generatedEnums = new HashSet<string>();

// 1) Générer d'abord les enums référencés (components schemas qui sont des enums)
foreach (var refName in allRefs.ToList())
{
    if (!document.Components.Schemas.TryGetValue(refName, out var s)) continue;
    if (s.Enum != null && s.Enum.Count > 0)
    {
        string enumName = CleanClassName(refName);
        GenerateEnumFile(enumName, s, outputDir, targetNamespace, generatedEnums);
    }
}

// 2) Générer les classes nécessaires (ignorer les schémas qui ne sont que des enums)
foreach (var refName in allRefs)
{
    if (!document.Components.Schemas.TryGetValue(refName, out var schema))
        continue;

    if (schema.Enum != null && schema.Enum.Count > 0)
    {
        // déjà généré comme enum -> on skip la génération de classe
        continue;
    }

    string className = CleanClassName(refName);

    var sb = new StringBuilder();
    sb.AppendLine("using Newtonsoft.Json;");
    sb.AppendLine("using System;");
    sb.AppendLine("using System.Collections.Generic;");
    sb.AppendLine();
    sb.AppendLine($"namespace {targetNamespace}");
    sb.AppendLine("{");
    sb.AppendLine($"    public class {className}");
    sb.AppendLine("    {");

    foreach (var propKvp in schema.Properties)
    {
        string propName = propKvp.Key;
        var prop = propKvp.Value;

        string typeName = ResolvePropertyType(prop, document, className, propName, outputDir, targetNamespace, generatedEnums);

        sb.AppendLine($"        [Newtonsoft.Json.JsonProperty(\"{propName}\")]");
        sb.AppendLine($"        public {typeName} {ToPascalCase(propName)} {{ get; set; }}");
        sb.AppendLine();
    }

    sb.AppendLine("    }");
    sb.AppendLine("}");

    File.WriteAllText(Path.Combine(outputDir, $"{className}.cs"), sb.ToString());
}

Console.WriteLine($"✅ Classes et enums générés dans {outputDir} pour l'endpoint {targetEndpoint}");

// -------- Fonctions utilitaires --------

static void CollectSchemaRefs(OpenApiSchema schema, HashSet<string> refs, OpenApiDocument doc)
{
    if (schema == null) return;

    if (schema.Reference != null)
    {
        string refId = schema.Reference.Id;
        if (!refs.Add(refId))
            return; // déjà ajouté

        if (doc.Components.Schemas.TryGetValue(refId, out var refSchema))
        {
            // Parcours des propriétés du schéma référencé
            if (refSchema.Properties != null)
                foreach (var prop in refSchema.Properties.Values)
                    CollectSchemaRefs(prop, refs, doc);

            // Si le schéma référencé est un tableau d'items $ref
            if (refSchema.Items != null)
                CollectSchemaRefs(refSchema.Items, refs, doc);
        }
    }
    else
    {
        // Inline schema : parcourir items (array) ou propriétés (object)
        if (schema.Items != null)
            CollectSchemaRefs(schema.Items, refs, doc);

        if (schema.Properties != null)
        {
            foreach (var prop in schema.Properties.Values)
                CollectSchemaRefs(prop, refs, doc);
        }
    }
}

static string ResolvePropertyType(
    OpenApiSchema schema,
    OpenApiDocument doc,
    string parentClassName,
    string propName,
    string outputDir,
    string targetNamespace,
    HashSet<string> generatedEnums)
{
    if (schema == null) return "object";

    // $ref => type is referenced schema (may be enum or class)
    if (schema.Reference != null)
    {
        var refId = schema.Reference.Id;
        // if referenced schema is an enum, ensure enum generated
        if (doc.Components.Schemas.TryGetValue(refId, out var refSchema) && refSchema.Enum != null && refSchema.Enum.Count > 0)
        {
            string enumName = CleanClassName(refId);
            GenerateEnumFile(enumName, refSchema, outputDir, targetNamespace, generatedEnums);
            return enumName;
        }

        return CleanClassName(refId);
    }

    // Inline enum defined directly on the property
    if (schema.Enum != null && schema.Enum.Count > 0)
    {
        string enumName = CleanClassName(parentClassName + "_" + propName + "_Enum");
        GenerateEnumFile(enumName, schema, outputDir, targetNamespace, generatedEnums);
        return enumName;
    }

    // Arrays
    if (schema.Type == "array")
    {
        var itemType = ResolvePropertyType(schema.Items, doc, parentClassName, propName + "Item", outputDir, targetNamespace, generatedEnums);
        return $"List<{itemType}>";
    }

    // Simple types
    return schema.Type switch
    {
        "integer" => schema.Format == "int64" ? "long" : "int",
        "number" => schema.Format == "float" ? "float" : "double",
        "string" => "string",
        "boolean" => "bool",
        "object" => "object",
        _ => "object"
    };
}

static void GenerateEnumFile(string enumName, OpenApiSchema schema, string outputDir, string targetNamespace, HashSet<string> generatedEnums)
{
    if (generatedEnums.Contains(enumName)) return; // déjà généré
    generatedEnums.Add(enumName);

    // Récupérer les valeurs brutes depuis schema.Enum (IOpenApiAny)
    var rawValues = new List<string>();
    foreach (var any in schema.Enum)
    {
        switch (any)
        {
            case OpenApiString s:
                rawValues.Add(s.Value ?? string.Empty);
                break;
            case OpenApiInteger i:
                rawValues.Add(i.Value.ToString(CultureInfo.InvariantCulture));
                break;
            case OpenApiDouble d:
                rawValues.Add(d.Value.ToString(CultureInfo.InvariantCulture));
                break;
            default:
                // fallback : ToString() (peut inclure guillemets, on nettoie)
                var t = any?.ToString() ?? string.Empty;
                rawValues.Add(t.Trim('"'));
                break;
        }
    }

    // Détecter si ce sont des valeurs numériques uniquement
    bool allNumeric = rawValues.All(v => long.TryParse(v, NumberStyles.Integer, CultureInfo.InvariantCulture, out _));

    string underlying = "int";
    if (schema.Type == "integer" && schema.Format == "int64") underlying = "long";
    if (allNumeric && schema.Format == "int64") underlying = "long";

    var sb = new StringBuilder();
    sb.AppendLine("using Newtonsoft.Json;");
    sb.AppendLine("using Newtonsoft.Json.Converters;");
    sb.AppendLine("using System.Runtime.Serialization;");
    sb.AppendLine();
    sb.AppendLine($"namespace {targetNamespace}");
    sb.AppendLine("{");

    if (!allNumeric)
    {
        // String enum: use StringEnumConverter + EnumMember for exact mapping
        sb.AppendLine($"    [JsonConverter(typeof(StringEnumConverter))]");
        sb.AppendLine($"    public enum {enumName}");
        sb.AppendLine("    {");

        var usedNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < rawValues.Count; i++)
        {
            var raw = rawValues[i] ?? string.Empty;
            var memberName = SanitizeEnumMemberName(raw);

            // éviter les doublons de noms
            var baseName = memberName;
            int suffix = 1;
            while (usedNames.Contains(memberName))
            {
                memberName = baseName + "_" + suffix++;
            }
            usedNames.Add(memberName);

            sb.AppendLine($"        [EnumMember(Value = \"{raw}\")]");
            sb.AppendLine($"        {memberName},");
        }

        sb.AppendLine("    }");
    }
    else
    {
        // Numeric enum: map numeric values
        sb.AppendLine($"    public enum {enumName} : {underlying}");
        sb.AppendLine("    {");

        var usedNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < rawValues.Count; i++)
        {
            var raw = rawValues[i];
            var memberName = SanitizeEnumMemberName(raw);

            var baseName = memberName;
            int suffix = 1;
            while (usedNames.Contains(memberName))
            {
                memberName = baseName + "_" + suffix++;
            }
            usedNames.Add(memberName);

            sb.AppendLine($"        {memberName} = {raw},");
        }

        sb.AppendLine("    }");
    }

    sb.AppendLine("}");

    File.WriteAllText(Path.Combine(outputDir, $"{enumName}.cs"), sb.ToString());
}

static string SanitizeEnumMemberName(string raw)
{
    if (raw == null) raw = string.Empty;
    // Remplacer tout ce qui n'est pas alphanum par underscore
    var cleaned = Regex.Replace(raw, @"[^A-Za-z0-9]", "_");
    // Coller les underscores multiples
    cleaned = Regex.Replace(cleaned, @"_+", "_").Trim('_');

    if (string.IsNullOrEmpty(cleaned))
        cleaned = "Value";

    // Si commence par chiffre, préfixer par underscore
    if (char.IsDigit(cleaned[0]))
        cleaned = "_" + cleaned;

    // PascalCase chaque segment
    var parts = cleaned.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(p => char.ToUpperInvariant(p[0]) + (p.Length > 1 ? p.Substring(1) : string.Empty));
    var result = string.Concat(parts);

    // Si toujours invalide, fallback
    if (string.IsNullOrEmpty(result))
        result = "Value";

    // Éviter mot-clé C# basique — si conflit, prefixer
    var csharpKeywords = new HashSet<string>(new[] { "Class", "Enum", "New", "Public", "Private", "Internal", "Protected", "Void", "Int", "String" }, StringComparer.OrdinalIgnoreCase);
    if (csharpKeywords.Contains(result))
        result = "_" + result;

    return result;
}

static string ToPascalCase(string text)
{
    if (string.IsNullOrEmpty(text)) return text;
    var parts = Regex.Split(text, @"[^A-Za-z0-9]+")
                     .Where(p => p.Length > 0)
                     .Select(p => char.ToUpperInvariant(p[0]) + (p.Length > 1 ? p.Substring(1) : string.Empty));
    var res = string.Concat(parts);
    if (string.IsNullOrEmpty(res)) res = text;
    if (char.IsDigit(res[0])) res = "_" + res;
    return res;
}

static string CleanClassName(string name)
{
    if (string.IsNullOrEmpty(name)) return name;

    // Supprimer toute occurrence débutante de teambuilderdirect (peu importe la casse)
    name = Regex.Replace(name, @"(?i)^teambuilderdirect", string.Empty);

    // Supprimer préfixes communs en minuscules ou fusionnés (ex: teambuilderdirecttypes)
    name = Regex.Replace(name, @"(?i)^teambuilderdirecttypes", string.Empty);

    // Retirer caractères non alphanumériques
    name = Regex.Replace(name, @"[^A-Za-z0-9]", string.Empty);

    // Si commence par chiffre, préfixer _
    if (char.IsDigit(name[0]))
        name = "_" + name;

    // PascalCase (déjà nettoyé, donc juste capitaliser la première lettre)
    return ToPascalCase(name);
}
