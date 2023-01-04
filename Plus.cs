using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickSwitchCombination
{
    internal class Plus : MonoBehaviour
    {
        public Plus(IntPtr intPtr) : base(intPtr)
        {
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener((UnityAction)OnClick);
        }

        private void OnClick()
        {
            Save.Settings.datas.Add(new Data(KeyCode.None, 0, -1));
            Menu.SetCombination(Save.Settings.datas.Count - 1);
        }
    }
}