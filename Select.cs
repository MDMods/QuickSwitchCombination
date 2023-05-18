using System;
using Assets.Scripts.Database;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickSwitchCombination;

internal class Select : MonoBehaviour
{
    private int count;

    public Select(IntPtr intPtr) : base(intPtr)
    {
    }

    private void Start()
    {
        count = transform.parent.gameObject.GetComponent<Count>().count;
        GetComponent<Button>().onClick.AddListener((UnityAction)OnClick);
    }

    private void OnClick()
    {
        DataHelper.selectedRoleIndex = Save.Settings.Data[count].Character;
        DataHelper.selectedElfinIndex = Save.Settings.Data[count].Elfin;
    }
}