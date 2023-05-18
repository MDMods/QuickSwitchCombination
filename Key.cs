using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static QuickSwitchCombination.Main;

namespace QuickSwitchCombination;

internal class Key : MonoBehaviour
{
    public Key(IntPtr intPtr) : base(intPtr)
    {
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener((UnityAction)OnClick);
    }

    private void OnClick()
    {
        SetKey = true;
        ClickIndex = transform.parent.gameObject.GetComponent<Count>().count;
    }
}