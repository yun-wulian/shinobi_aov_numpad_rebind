# SHINOBI_AOV Numpad Rebind

Enables binding numpad keys in SHINOBI_AOV by extending the game's keyboard rebind whitelist.

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

Copy `NumpadRebind.dll` to:
- `<GameRoot>\BepInEx\plugins\NumpadRebind.dll`
