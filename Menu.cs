using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.PeroTools.Managers;
using Assets.Scripts.PeroTools.Commons;

namespace QuickSwitchCombination
{
    public class Menu : MonoBehaviour
    {
        public Menu(IntPtr intPtr) : base(intPtr)
        {
        }

        public static bool ShowMenu = false;

        private void OnGUI()
        {
            if (ShowMenu)
            {
                GUI.Box(new Rect(Screen.width - 460, 0, 460, Screen.height), "QuickSwitchCombination");
                /*GUI.Label(new Rect(Screen.width - 200, 30, 200, 20), "Character Skill: " + Main.CharacterSkill.ToString());
                if (GUI.Button(new Rect(Screen.width - 200, 60, 200, 20), "Default"))
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
                }*/
            }
        }
    }
}