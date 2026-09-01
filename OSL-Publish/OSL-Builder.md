# 🚀 OSL Builder

OSL Builder is a Windows batch script used to build and publish the OSL applications.

## 📋 Requirements

Before using the script, make sure you have installed:

* .NET SDK
* 7-Zip

The script uses:

* `dotnet publish` to build the applications.
* 7-Zip to create ZIP archives.

---

## ▶️ How to Use

Simply run:

`OSL-Builder.bat`

You can double-click the file or run it from a terminal.

---

## 📦 Available Builds

The script can build:

* 🖥️ **OSL-Server** for Windows (`win-x64`)
* 🪟 **OSL-Overlay** for Windows (`win-x64`)
* 🐧 **OSL-Overlay** for Linux (`linux-x64`)

You can build everything or select specific targets.

---

## 🔧 Build Configuration

Choose one of the following configurations:

* 🚀 **Release** — Recommended for distribution.
* 🐞 **Debug** — Intended for development and testing.

---

## 🏷️ Release Type

Available release types:

* Alpha
* Beta
* Release Candidate
* Release

---

## 🔢 Version

Versions must follow the format:

`X.Y.Z`

Examples:

```text
1.0.0
2.1.4
10.25.100
```

You can leave the version field empty to keep the current version.

---

## 📝 Version Files

The following files are updated when the build is confirmed:

* `version.json`
* `Version.props`

If the build is cancelled before confirmation, these files are not modified.

---

## 📁 Output

Published applications are generated in:

`OSL-Publish`

Example:

```text
OSL-Publish
├── OSL-Server
│   └── win-x64
└── OSL-Overlay
    ├── win-x64
    └── linux-x64
```

---

## 📦 ZIP Archives

ZIP archives can be generated after a build or directly from existing publish folders.

Example:

```text
OSL-Server-1.0.0-win-x64.zip
OSL-Overlay-1.0.0-win-x64.zip
OSL-Overlay-1.0.0-linux-x64.zip
```

---

## ⚠️ Notes

* Previous publish folders are removed before creating a new build if is the same version.
* Make sure 7-Zip is installed before generating ZIP archives.
* Use the `Release` configuration for production builds.
