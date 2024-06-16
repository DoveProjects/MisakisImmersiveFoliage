using HarmonyLib;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;
using Vintagestory.Essentials;

namespace Vintagestory.GameContent
{
    [HarmonyPatch(typeof(BlockLeaves))]
    [HarmonyPatch(typeof(BlockBerryBush))]
    [HarmonyPatch("GetCollisionBoxes")]

    public class MIF : ModSystemAuction
    class BEBehaviorSupportBeam_GetCollisionBoxes_Patch
    {
        static bool Prefix(ref Cuboidf[] __result)
        {
            __result = System.Array.Empty<Cuboidf>();
            return false;
        }
    }
}