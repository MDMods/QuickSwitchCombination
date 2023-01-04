using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Managers;
using Il2CppSystem.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickSwitchCombination
{
    internal class Character : MonoBehaviour
    {
        private int count;

        public Character(IntPtr intPtr) : base(intPtr)
        {
        }

        private void Start()
        {
            count = transform.parent.gameObject.GetComponent<Count>().count;
            var dropdown = GetComponent<Dropdown>();
            dropdown.ClearOptions();

            List<string> characters = new();
            for (int i = 0; i < Singleton<ConfigManager>.instance["character"].Count; i++)
            {
                characters.Add(Singleton<ConfigManager>.instance.GetJson("character", true)[i]["cosName"].ToObject<string>());
            }
            dropdown.AddOptions(characters);

            dropdown.value = Save.Settings.datas[count].Character;
            dropdown.onValueChanged.AddListener((UnityAction<int>)OnValueChanged);
        }

        private void OnValueChanged(int index)
        {
            var Data = Save.Settings.datas[count];
            Data.Character = index;
            Save.Settings.datas[count] = Data;
        }
    }
}