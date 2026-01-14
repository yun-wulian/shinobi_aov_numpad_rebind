# Release notes

## v0.1.1

- Adds a ready-to-extract zip with the correct `BepInEx\plugins\` folder structure.

## v0.1.0

- Enables binding numpad keys by extending the game's keyboard rebind whitelist.

### Install

1. Install BepInEx IL2CPP for the game.
2. Launch the game once to generate `BepInEx/interop`.
3. Copy `NumpadRebind.dll` into:
   - `<GameRoot>\BepInEx\plugins\NumpadRebind.dll`

Notes:
- BepInEx build site: https://builds.bepinex.dev/
- BepInEx project page: https://builds.bepinex.dev/projects/bepinex_be
- Known-good BepInEx IL2CPP build for Unity `2021.3.45f1` / IL2CPP metadata v31 (Windows x64):
  - https://builds.bepinex.dev/projects/bepinex_be/752/BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.752%2Bdd0655f.zip
