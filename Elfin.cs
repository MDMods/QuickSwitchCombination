using System;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Managers;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickSwitchCombination;

internal class Elfin : MonoBehaviour
{
    private int count;

    public Elfin(IntPtr intPtr) : base(intPtr)
    {
    }

    private void Start()
    {
        count = transform.parent.gameObject.GetComponent<Count>().count;
        var dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();

        List<string> elfins = new();
        elfins.Add("None");
        for (var i = 0; i < Singleton<ConfigManager>.instance["elfin"].Count; i++)
        {
            elfins.Add(Singleton<ConfigManager>.instance.GetJson("elfin", true)[i]["name"].ToObject<string>());
        }

        dropdown.AddOptions(elfins);

        dropdown.value = Save.Settings.datas[count].Elfin + 1;
        dropdown.onValueChanged.AddListener((UnityAction<int>)OnValueChanged);
    }

    private void OnValueChanged(int index)
    {
        var Data = Save.Settings.datas[count];
        Data.Elfin = index - 1;
        Save.Settings.datas[count] = Data;
    }
}