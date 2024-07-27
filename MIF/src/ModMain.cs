using HarmonyLib;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Ele.Configuration;
using System;

namespace Ele.MIF
{
    public class ModMain : ModSystem
    {
        private ICoreServerAPI _sapi = null!;
        private ICoreClientAPI _capi = null!;

        public static ModConfig LoadedConfig;

        public override void StartPre(ICoreAPI api)
        {
            base.StartPre(api);
            if (api.ModLoader.IsModEnabled("configlib"))
            {
                _ = new ConfigLibCompat(api);
            }
        }

        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            LoadedConfig = ConfigHelper.ReadConfig<ModConfig>(api);

            if (api.Side == EnumAppSide.Server)
            {
                api.World.Config.SetString("Leaf_Model_Type", LoadedConfig.Leaf_Model_Type.ToString());
                api.World.Config.SetBool("Use_Vanilla_Bushes", LoadedConfig.Use_Vanilla_Bushes);
                api.World.Config.SetBool("Branchy_Collision", LoadedConfig.Branchy_Collision);
            }
        }
        public override void AssetsFinalize(ICoreAPI api)
        {
            base.AssetsFinalize(api);
        }

        public override void StartServerSide(ICoreServerAPI sapi)
        {
            _sapi = sapi;
        }

        public override void StartClientSide(ICoreClientAPI capi)
        {
            _capi = capi;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
