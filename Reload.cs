using System;
using System.IO;
using Tomlet;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickSwitchCombination
{
    internal class Reload : MonoBehaviour
    {
        public Reload(IntPtr intPtr) : base(intPtr)
        {
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener((UnityAction)OnClick);
        }

        private void OnClick()
        {
            string Configs = File.ReadAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"));
            Save.Settings = TomletMain.To<Config>(Configs);

            for (int i = 0; i < ConstantVariables.ContentTransform.childCount; i++)
            {
                Destroy(ConstantVariables.ContentTransform.GetChild(i).gameObject);
            }

            for (int i = 0; i < Save.Settings.datas.Count; i++)
            {
                Menu.SetCombination(i);
            }
        }
    }
}