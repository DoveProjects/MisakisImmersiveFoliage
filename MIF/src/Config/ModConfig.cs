using Newtonsoft.Json;
using Vintagestory.API.Common;
using Ele.Configuration;


namespace Ele.MIF
{
    public class ModConfig : IModConfig
    {
        [JsonIgnore]
        public bool Is_Enabled { get; set; }

        public ModelType Leaf_Model_Type { get; set; }
        public bool Use_Vanilla_Bushes { get; set; }
        public bool Branchy_Collision { get; set; }


        public ModConfig(ICoreAPI api, ModConfig previousConfig = null)
        {
            Is_Enabled = previousConfig?.Is_Enabled ?? true;

            Leaf_Model_Type = previousConfig?.Leaf_Model_Type ?? ModelType.Lite;
            Use_Vanilla_Bushes = previousConfig?.Use_Vanilla_Bushes ?? false;
            Branchy_Collision = previousConfig?.Branchy_Collision ?? false;
        }

        public enum ModelType
        {
            Lite,
            Full
        }
    }
}