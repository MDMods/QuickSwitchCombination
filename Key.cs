using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
        Main.SetKey = true;
        Main.ClickIndex = transform.parent.gameObject.GetComponent<Count>().count;
    }
}