# SHINOBI_AOV Numpad Rebind

Enables binding numpad keys in SHINOBI_AOV by extending the game's keyboard rebind whitelist.

## Prerequisites

This mod is a **BepInEx IL2CPP** plugin.

Users must install BepInEx IL2CPP for the game first (this creates the `dotnet/` folder and `BepInEx/` loader setup).

### BepInEx download

- BepInEx build site (recommended for IL2CPP bleeding-edge builds): https://builds.bepinex.dev/
- Project page: https://builds.bepinex.dev/projects/bepinex_be

Known-good BepInEx IL2CPP build for Unity `2021.3.45f1` / IL2CPP metadata v31 (Windows x64):

- `BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.752+dd0655f.zip`
- https://builds.bepinex.dev/projects/bepinex_be/752/BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.752%2Bdd0655f.zip

## Build notes

This project references game-specific assemblies produced by BepInEx IL2CPP (`BepInEx/interop` and `BepInEx/core`).

- Ensure BepInEx IL2CPP is installed for the game.
- Launch the game once so `BepInEx/interop` is generated.

Then build from this folder:

```powershell
dotnet build -c Release
```

The plugin DLL to copy into the game is:
- `bin/Release/net6.0/NumpadRebind.dll`

## Install

Option A (manual copy):
- Copy `NumpadRebind.dll` to `<GameRoot>\BepInEx\plugins\NumpadRebind.dll`

Option B (recommended):
- Download `NumpadRebind-BepInExPlugins.zip` from Releases and extract it into `<GameRoot>`.
