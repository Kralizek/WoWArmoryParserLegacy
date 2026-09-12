# WoWArmoryParser Legacy

This repository preserves **WoWArmoryParser**, one of my earliest open-source projects, originally published on CodePlex around 2007.

WoWArmoryParser is a VB.NET library that consumed Blizzard's original World of Warcraft Armory XML endpoints and exposed strongly typed models for characters, guilds, arena teams, items, reputations, skills, and related game data.

## Status

This project is preserved for historical purposes. The original World of Warcraft Armory service no longer exists, so the library is not usable with Blizzard's current APIs and is not actively maintained.

The source code itself remains in VB.NET and targets .NET Framework. The repository scaffolding has been modernized so the library can still be opened and built with current tooling:

- SDK-style Visual Basic project
- .NET Framework 4.8 target
- modern solution file
- GitHub Actions build

No attempt has been made to port the implementation to C# or adapt it to Blizzard's current REST APIs.

## Building

You need a current .NET SDK. The project uses the `Microsoft.NETFramework.ReferenceAssemblies` package so the .NET Framework 4.8 reference assemblies are available during restore.

```text
dotnet build WoWArmoryParserLegacy.sln
```

## History

The recovered source identifies version `0.5.1.0` and carries a 2007 copyright notice. It was recovered from a personal backup in September 2026 after the original CodePlex-hosted project had long since disappeared.
