using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Managers;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;
using MelonLoader;
using UnityEngine;
using UnhollowerRuntimeLib;

namespace QuickSwitchCombination
{
    public class Main : MelonMod
    {
        private static int n = 0;
        private static GameObject gameobject { get; set; }
        private static KeyCode InputKey { get; set; }

        public override void OnInitializeMelon()
        {
            Save.Load();
            LoggerInstance.Msg("QuickSwitchCombination is loaded!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "UISystem_PC")
            {
                ClassInjector.RegisterTypeInIl2Cpp<Menu>();
                gameobject = new GameObject("QuickSwitchCombination");
                Object.DontDestroyOnLoad(gameobject);
                gameobject.AddComponent<Menu>();
            }
            else
            {
                Object.Destroy(gameobject);
            }
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
                if (Save.Settings.datas[n].Elfin == "")
                {
                    VariableUtils.SetResult(Singleton<DataManager>.instance["Account"]["SelectedElfinIndex"], new Il2CppSystem.Int32() { m_value = -1 }.BoxIl2CppObject());
                }
            }
        }
    }
}