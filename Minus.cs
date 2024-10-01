using System;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static QuickSwitchCombination.ConstantVariables;

namespace QuickSwitchCombination;

[RegisterTypeInIl2Cpp]
internal class Minus : MonoBehaviour
{
    public Minus(IntPtr intPtr) : base(intPtr)
    {
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener((UnityAction)OnClick);
    }

    private void OnClick()
    {
        Destroy(ContentTransform.GetChild(ContentTransform.childCount - 1).gameObject);
        Save.Settings.Data.RemoveAt(Save.Settings.Data.Count - 1);
    }
}