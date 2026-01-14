using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Mist.Managers;
using Mist.UI.Menu;
using UnityEngine;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public sealed class NumpadRebindPlugin : BasePlugin
{
    public const string PluginGuid = "com.yunwulian.shinobi_aov.numpad-rebind";
    public const string PluginName = "SHINOBI_AOV Numpad Rebind";
    public const string PluginVersion = "0.1.0";

    internal static ManualLogSource? LoggerInstance;

    public override void Load()
    {
        LoggerInstance = Log;

        try
        {
            var harmony = new Harmony(PluginGuid);
            harmony.PatchAll();
            Log.LogInfo("Loaded; Harmony patches applied.");
        }
        catch (Exception ex)
        {
            Log.LogError($"Failed to apply Harmony patches: {ex}");
        }
    }

    internal static bool IsNumpadKey(KeyCode key)
    {
        return key is
            KeyCode.Keypad0 or
            KeyCode.Keypad1 or
            KeyCode.Keypad2 or
            KeyCode.Keypad3 or
            KeyCode.Keypad4 or
            KeyCode.Keypad5 or
            KeyCode.Keypad6 or
            KeyCode.Keypad7 or
            KeyCode.Keypad8 or
            KeyCode.Keypad9 or
            KeyCode.KeypadPeriod or
            KeyCode.KeypadDivide or
            KeyCode.KeypadMultiply or
            KeyCode.KeypadMinus or
            KeyCode.KeypadPlus or
            KeyCode.KeypadEnter or
            KeyCode.KeypadEquals;
    }
}

/// <summary>
/// The game uses a whitelist for which KeyCodes can be rebound for gameplay.
/// Patching the whitelist is safer than patching the per-input polling callbacks, because
/// Rewired's ControllerPollingInfo is an IL2CPP value-type wrapper and boxing it can crash.
/// </summary>
[HarmonyPatch(typeof(InputManager), nameof(InputManager.GetKeyboardAllowedKeyCodeForGameplayRebind))]
internal static class Patch_InputManager_GetKeyboardAllowedKeyCodeForGameplayRebind
{
    private static void Postfix(ref Il2CppSystem.Collections.Generic.List<KeyCode> __result)
    {
        if (__result is null)
            return;

        var keysToAdd = new[]
        {
            KeyCode.Keypad0,
            KeyCode.Keypad1,
            KeyCode.Keypad2,
            KeyCode.Keypad3,
            KeyCode.Keypad4,
            KeyCode.Keypad5,
            KeyCode.Keypad6,
            KeyCode.Keypad7,
            KeyCode.Keypad8,
            KeyCode.Keypad9,
            KeyCode.KeypadPeriod,
            KeyCode.KeypadDivide,
            KeyCode.KeypadMultiply,
            KeyCode.KeypadMinus,
            KeyCode.KeypadPlus,
            KeyCode.KeypadEnter,
            KeyCode.KeypadEquals,
        };

        var addedAny = false;
        foreach (var key in keysToAdd)
        {
            if (!__result.Contains(key))
            {
                __result.Add(key);
                addedAny = true;
            }
        }

        if (addedAny)
            NumpadRebindPlugin.LoggerInstance?.LogInfo("Extended keyboard rebind whitelist to include numpad keys.");
    }
}
