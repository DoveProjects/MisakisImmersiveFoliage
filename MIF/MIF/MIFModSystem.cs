using HarmonyLib;
using Vintagestory.GameContent;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;
using Vintagestory.Essentials;

namespace Vintagestory.GameContent
{
    [HarmonyPatch(typeof(BlockLeaves))]
    [HarmonyPatch("GetCollisionBoxes")]
    
    public class MIF : ModSystem
    {
        ICoreClientAPI api;
    }
    class GetCollisionBoxes_Patch
    {
        static bool Prefix(ref Cuboidf[] __result)
        {
            __result = System.Array.Empty<Cuboidf>();
            return false;
        }
    }
}