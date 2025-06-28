using BepInEx;
using HarmonyLib;

[BepInPlugin("ant2357.one_gold_expansion_mod", "One Gold Expansion Mod", "1.0.1")]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        var harmony = new Harmony("ant2357.one_gold_expansion_mod");
        harmony.PatchAll();
    }
}

// 土地拡張費用を常に金塊 1 個にするパッチ
[HarmonyPatch(typeof(CalcGold), nameof(CalcGold.ExpandLand))]
public static class ExpandLandPatch
{
    [HarmonyPostfix]
    public static void Postfix(ref int __result)
    {
        __result = 1;
    }
}
