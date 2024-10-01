using System;
using Il2CppAssets.Scripts.Database;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickSwitchCombination;

[RegisterTypeInIl2Cpp]
internal class Select : MonoBehaviour
{
    private int _count;

    public Select(IntPtr intPtr) : base(intPtr)
    {
    }

    private void Start()
    {
        _count = transform.parent.gameObject.GetComponent<Count>().count;
        GetComponent<Button>().onClick.AddListener((UnityAction)OnClick);
    }

    private void OnClick()
    {
        DataHelper.selectedRoleIndex = Save.Settings.Data[_count].Character;
        DataHelper.selectedElfinIndex = Save.Settings.Data[_count].Elfin;
    }
}