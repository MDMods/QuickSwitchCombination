using System;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickSwitchCombination;

[RegisterTypeInIl2Cpp]
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
        Save.Settings.Data.Add(new Data(0, -1, KeyCode.None));
        Menu.SetCombination(Save.Settings.Data.Count - 1);
    }
}