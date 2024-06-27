using System.Collections.Generic;
using Vintagestory.API.Common;

namespace MIF.Config
{
    public class MIFConfig : IModConfig
    {
        public bool Branchy_Collision_Enabled { get; set; } = false;

        public float Normal_Movement_Penalty = 0.75f;

        public float Branchy_Movement_Penalty = 0.5f;

        public MIFConfig(ICoreAPI api, MIFConfig previousConfig = null)
        {
            if (previousConfig != null)
            {
                Branchy_Collision_Enabled = previousConfig.Branchy_Collision_Enabled;
                Normal_Movement_Penalty = previousConfig.Normal_Movement_Penalty;
                Branchy_Movement_Penalty = previousConfig.Branchy_Movement_Penalty;
            }
        }
    }
}