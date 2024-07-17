using System;
using System.Linq;
using System.Collections.Generic;
using Vintagestory.API.Config;
using Vintagestory.API.Common;
using ConfigLib;
using ImGuiNET;
using Ele.Configuration;

namespace Ele.MIF
{
    //Courtesy of https://github.com/maltiez2/ && https://github.com/Craluminum-Mods/
    public class ConfigLibCompat
    {
        public ConfigLibModSystem ConfigLib { get; set; }

        private const string settingPrefix = $"{ModConstants.modDomain}:Config.Setting.";


        public ConfigLibCompat(ICoreAPI api)
        {
            ConfigLib = api.ModLoader.GetModSystem<ConfigLibModSystem>();
            ConfigLib.RegisterCustomConfig($"{ModConstants.modDomain}", (id, buttons) => EditConfig(id, buttons, api));
        }

        private void EditConfig(string id, ControlButtons buttons, ICoreAPI api)
        {
            if (buttons.Save) ModMain.LoadedConfig = ConfigManager.UpdateConfig(api, ModMain.LoadedConfig);
            if (buttons.Restore) ModMain.LoadedConfig = ConfigManager.ReadConfig<ModConfig>(api, ConfigManager.GetConfigPath(api));
            if (buttons.Defaults) ModMain.LoadedConfig = new(api);
            Edit(api, ModMain.LoadedConfig, id);
        }

        private void Edit(ICoreAPI api, ModConfig config, string id)
        {
            ImGui.TextWrapped(Lang.Get(ModConstants.modDomain + ":mod-title"));

            config.Leaf_Model_Type = OnInputEnum(id, config.Leaf_Model_Type, nameof(config.Leaf_Model_Type));
            config.Use_Vanilla_Bushes = OnCheckBox(id, config.Use_Vanilla_Bushes, nameof(config.Use_Vanilla_Bushes));
        }

        #region Helpers
        /// <summary>
        ///     <------------------Helper methods for setting up GUI elements------------------->
        /// </summary>
        private bool OnCheckBox(string id, bool value, string name, bool isDisabled = false)
        {
            bool newValue = value && !isDisabled;
            if (isDisabled)
            {
                ImGui.PushStyleVar(ImGuiStyleVar.Alpha, ImGui.GetStyle().Alpha * 0.5f);
            }
            if (ImGui.Checkbox(Lang.Get(settingPrefix + name) + $"##{name}-{id}", ref newValue))
            {
                if (isDisabled)
                {
                    newValue = value;
                }
            }
            if (isDisabled)
            {
                ImGui.PopStyleVar();
            }
            return newValue;
        }

        private int OnInputInt(string id, int value, string name, int minValue = default)
        {
            int newValue = value;
            ImGui.InputInt(Lang.Get(settingPrefix + name) + $"##{name}-{id}", ref newValue, step: 1, step_fast: 10);
            return newValue < minValue ? minValue : newValue;
        }

        private float OnInputFloat(string id, float value, string name, float minValue = default)
        {
            float newValue = value;
            ImGui.InputFloat(Lang.Get(settingPrefix + name) + $"##{name}-{id}", ref newValue, step: 0.01f, step_fast: 1.0f);
            return newValue < minValue ? minValue : newValue;
        }

        private double OnInputDouble(string id, double value, string name, double minValue = default)
        {
            double newValue = value;
            ImGui.InputDouble(Lang.Get(settingPrefix + name) + $"##{name}-{id}", ref newValue, step: 0.01f, step_fast: 1.0f);
            return newValue < minValue ? minValue : newValue;
        }

        private string OnInputText(string id, string value, string name)
        {
            string newValue = value;
            ImGui.InputText(Lang.Get(settingPrefix + name) + $"##{name}-{id}", ref newValue, 64);
            return newValue;
        }

        private IEnumerable<string> OnInputTextMultiline(string id, IEnumerable<string> values, string name)
        {
            string newValue = values.Any() ? values.Aggregate((first, second) => $"{first}\n{second}") : "";
            ImGui.InputTextMultiline(Lang.Get(settingPrefix + name) + $"##{name}-{id}", ref newValue, 256, new(0, 0));
            return newValue.Split('\n', StringSplitOptions.RemoveEmptyEntries).AsEnumerable();
        }

        private T OnInputEnum<T>(string id, T value, string name) where T : Enum
        {
            string[] enumNames = Enum.GetNames(typeof(T));
            int index = Array.IndexOf(enumNames, value.ToString());

            if (ImGui.Combo(Lang.Get(settingPrefix + name) + $"##{name}-{id}", ref index, enumNames, enumNames.Length))
            {
                value = (T)Enum.Parse(typeof(T), enumNames[index]);
            }

            return value;
        }

        private List<string> OnInputList(string id, List<string> values, string name)
        {
            List<string> newValues = new List<string>(values);
            for (int i = 0; i < newValues.Count; i++)
            {
                string newValue = newValues[i];
                ImGui.InputText($"{name}[{i}]##{name}-{id}-{i}", ref newValue, 64);
                newValues[i] = newValue;
            }

            if (ImGui.Button($"Add##{name}-{id}"))
            {
                newValues.Add("");
            }

            return newValues;
        }
        #endregion
    }
}
