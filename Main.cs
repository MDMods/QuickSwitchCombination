using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Managers;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;
using MelonLoader;
using System.IO;
using Tomlet;
using UnityEngine;
using UnhollowerRuntimeLib;

namespace QuickSwitchCombination
{
    public class Main : MelonMod
    {
        private static int n = 0;

        private static KeyCode InputKey;

        public override void OnApplicationStart()
        {
            Save.Load();
            ClassInjector.RegisterTypeInIl2Cpp<Menu>();
            GameObject gameObject = new GameObject("QuickSwitchCombination");
            Object.DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<Menu>();
            LoggerInstance.Msg("QuickSwitchCombination loaded");
        }

        public override void OnGUI()
        {
            if (Input.anyKeyDown)
            {
                Event e = Event.current;
                if (e != null && e.isKey && e.keyCode != KeyCode.None)
                {
                    InputKey = e.keyCode;
                    for (n = 0; n < Save.Settings.datas.Count; n++)
                    {
                        if (InputKey == Save.Settings.datas[n].Key)
                        {
                            SetCombination();
                        }
                    }
                    if (InputKey == Save.Settings.ReloadKey)
                    {
                        string Configs = File.ReadAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"));
                        Save.Settings = TomletMain.To<Config>(Configs);
                    }
                    if (InputKey == Save.Settings.MenuKey)
                    {
                        Menu.ShowMenu = !Menu.ShowMenu;
                    }
                }
            }
        }

        private void SetCombination()
        {
            for (int i = 0; i < Singleton<ConfigManager>.instance["character"].Count; i++)
            {
                if (Save.Settings.datas[n].Character == Singleton<ConfigManager>.instance.GetJson("character", true)[i]["cosName"].ToObject<string>())
                {
                    VariableUtils.SetResult(Singleton<DataManager>.instance["Account"]["SelectedRoleIndex"], new Il2CppSystem.Int32() { m_value = i }.BoxIl2CppObject());
                }
            }

            for (int i = 0; i < Singleton<ConfigManager>.instance["elfin"].Count; i++)
            {
                if (Save.Settings.datas[n].Elfin == Singleton<ConfigManager>.instance.GetJson("elfin", true)[i]["name"].ToObject<string>())
                {
                    VariableUtils.SetResult(Singleton<DataManager>.instance["Account"]["SelectedElfinIndex"], new Il2CppSystem.Int32() { m_value = i }.BoxIl2CppObject());
                }
            }
        }
    }
}