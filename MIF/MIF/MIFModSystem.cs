using HarmonyLib;
using Vintagestory.GameContent;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace Vintagestory.GameContent
{
    [HarmonyPatch(typeof(BlockLeaves))]
    [HarmonyPatch("GetCollisionBoxes")]
    class BEBehaviorSupportBeam_GetCollisionBoxes_Patch
    {
        static bool Prefix(ref Cuboidf[] __result)
        {
            __result = System.Array.Empty<Cuboidf>();
            return false;
        }
    }
}