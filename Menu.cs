using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.PeroTools.Managers;
using Assets.Scripts.PeroTools.Commons;
using MelonLoader;
using System.IO;
using Tomlet;
using UnityEngine.UI;

namespace QuickSwitchCombination
{
    public class Menu : MonoBehaviour
    {
        private static Dropdown CharacterDP = new Dropdown();
        private GameObject UI;

        public Menu(IntPtr intPtr) : base(intPtr)
        {
        }

        public static bool ShowMenu = false;

        private void Start()
        {
            MelonLogger.Msg("Menu loaded");
        }

        /*private void Update()
        {
            UI = UIFactory.CreateUIObject("SceneExplorer", );
            UIFactory.SetLayoutGroup<VerticalLayoutGroup>(uiRoot, true, true, true, true, 0, 2, 2, 2, 2);
            UIFactory.SetLayoutElement(uiRoot, flexibleHeight: 9999);
        }*/

        /*private void OnGUI()
        {
            if (ShowMenu)
            {
                GUI.Box(new Rect(Screen.width - 460, 0, 460, Screen.height), "QuickSwitchCombination");
                GameObject gameObject = new GameObject();
                UIFactory.CreateLabel(gameObject, "character", "Character");
                GUI.Label(new Rect(Screen.width - 390, 80, 100, 20), "Character");
                GUI.Label(new Rect(Screen.width - 240, 80, 100, 20), "Elfin");
                GUI.Label(new Rect(Screen.width - 120, 80, 100, 20), "Key");

                //if click reload button then reloading all settings
                if (GUI.Button(new Rect(Screen.width - 160, 40, 100, 20), "Reload"))
                {
                    string Configs = File.ReadAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"));
                    Save.Settings = TomletMain.To<Config>(Configs);
                    MelonLogger.Msg("Reloaded new settings");
                }

                //if click + button then add one more line of dropdowns to the box
                if (GUI.Button(new Rect(Screen.width - 400, 40, 100, 20), "+"))
                {
                }
                for (int i = 0; i < Save.Settings.datas.Count; i++)
                {
                }
                /*if (GUI.Button(new Rect(Screen.width - 200, 60, 200, 20), "Default"))
                {
                    Main.CharacterSkill = -1;
                }
                for (int i = 0; i < Singleton<ConfigManager>.instance["character"].Count; i++)
                {
                    if (GUI.Button(new Rect(Screen.width - 200, i * 30 + 90, 200, 20), Singleton<ConfigManager>.instance.GetJson("character", true)[i]["cosName"].ToObject<string>()))
                    {
                        Main.CharacterSkill = i;
                    }
                }
                GUI.Label(new Rect(Screen.width - 450, 30, 200, 20), "Elfin Skill: " + Main.ElfinSkill.ToString());
                if (GUI.Button(new Rect(Screen.width - 450, 60, 200, 20), "Default"))
                {
                    Main.ElfinSkill = -1;
                }
                for (int i = 0; i < Singleton<ConfigManager>.instance["elfin"].Count; i++)
                {
                    if (GUI.Button(new Rect(Screen.width - 450, i * 30 + 90, 200, 20), Singleton<ConfigManager>.instance.GetJson("elfin", true)[i]["name"].ToObject<string>()))
                    {
                        Main.ElfinSkill = i;
                    }
                }
            }
        }*/

        /*private Dropdown CreateDropDown(string name,)
        {
            return
        }*/
    }
}