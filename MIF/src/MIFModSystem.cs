using System.Collections.Generic;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using MIF.Config;

namespace MIF;
public class MIFModSystem : ModSystem
{
    public static MIFConfig MIFConfig { get; private set; }

    public override void AssetsFinalize(ICoreAPI api)
    {
        if (api.Side.IsServer())
        {
            MIFConfig = ModConfig.ReadConfig<MIFConfig>(api, "Misaki's Immersive Foliage.json");

            //Apply config values for use in json patches
            api.World.Config.SetBool("Branchy_Collision_Enabled", MIFConfig.Branchy_Collision_Enabled);
            api.World.Config.SetFloat("Normal_Movement_Penalty", MIFConfig.Normal_Movement_Penalty);
            api.World.Config.SetFloat("Branchy_Movement_Penalty", MIFConfig.Branchy_Movement_Penalty);
        }
    }
}