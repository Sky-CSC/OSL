using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a champion stats data transfer object.
    /// </summary>
    public struct ChampionStatsDto
    {
        /// <summary>
        /// The ability haste of the champion.
        /// </summary>
        [JsonProperty("abilityHaste")]
        public int AbilityHaste { get; set; }
        /// <summary>
        /// The ability power of the champion.
        /// </summary>
        [JsonProperty("abilityPower")]
        public int AbilityPower { get; set; }
        /// <summary>
        /// The armor of the champion.
        /// </summary>
        [JsonProperty("armor")]
        public int Armor { get; set; }
        /// <summary>
        /// The armor penetration
        /// </summary>
        [JsonProperty("armorPen")]
        public int ArmorPen { get; set; }
        /// <summary>
        /// The armor penetration percentage.
        /// </summary>
        [JsonProperty("armorPenPercent")]
        public int ArmorPenPercent { get; set; }
        /// <summary>
        /// The attack damage of the champion.
        /// </summary>
        [JsonProperty("attackDamage")]
        public int AttackDamage { get; set; }
        /// <summary>
        /// The attack speed of the champion.
        /// </summary>
        [JsonProperty("attackSpeed")]
        public int AttackSpeed { get; set; }
        /// <summary>
        /// The bonus armor penetration percentage.
        /// </summary>
        [JsonProperty("bonusArmorPenPercent")]
        public int BonusArmorPenPercent { get; set; }
        /// <summary>
        /// The bonus magic penetration percentage.
        /// </summary>
        [JsonProperty("bonusMagicPenPercent")]
        public int BonusMagicPenPercent { get; set; }
        /// <summary>
        /// The crowd control reduction.
        /// </summary>
        [JsonProperty("ccReduction")]
        public int CcReduction { get; set; }
        /// <summary>
        /// The cooldown reduction.
        /// </summary>
        [JsonProperty("cooldownReduction")]
        public int CooldownReduction { get; set; }
        /// <summary>
        /// The health of the champion.
        /// </summary>
        [JsonProperty("health")]
        public int Health { get; set; }
        /// <summary>
        /// The maximum health of the champion.
        /// </summary>
        [JsonProperty("healthMax")]
        public int HealthMax { get; set; }
        /// <summary>
        /// The health regeneration of the champion.
        /// </summary>
        [JsonProperty("healthRegen")]
        public int HealthRegen { get; set; }
        /// <summary>
        /// The lifesteal of the champion.
        /// </summary>
        [JsonProperty("lifesteal")]
        public int Lifesteal { get; set; }
        /// <summary>
        /// The magic penetration of the champion.
        /// </summary>
        [JsonProperty("magicPen")]
        public int MagicPen { get; set; }
        /// <summary>
        /// The magic penetration percentage.
        /// </summary>
        [JsonProperty("magicPenPercent")]
        public int MagicPenPercent { get; set; }
        /// <summary>
        /// The magic resist of the champion.
        /// </summary>
        [JsonProperty("magicResist")]
        public int MagicResist { get; set; }
        /// <summary>
        /// The movement speed of the champion.
        /// </summary>
        [JsonProperty("movementSpeed")]
        public int MovementSpeed { get; set; }
        /// <summary>
        /// The omnivamp of the champion.
        /// </summary>
        [JsonProperty("omnivamp")]
        public int Omnivamp { get; set; }
        /// <summary>
        /// The physical vamp of the champion.
        /// </summary>
        [JsonProperty("physicalVamp")]
        public int PhysicalVamp { get; set; }
        /// <summary>
        /// The power of the champion.
        /// </summary>
        [JsonProperty("power")]
        public int Power { get; set; }
        /// <summary>
        /// The maximum power of the champion.
        /// </summary>
        [JsonProperty("powerMax")]
        public int PowerMax { get; set; }
        /// <summary>
        /// The power regeneration of the champion.
        /// </summary>
        [JsonProperty("powerRegen")]
        public int PowerRegen { get; set; }
        /// <summary>
        /// The spell vamp of the champion.
        /// </summary>
        [JsonProperty("spellVamp")]
        public int SpellVamp { get; set; }
    }
}
