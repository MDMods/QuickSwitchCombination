using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickSwitchCombination
{
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
            VariableUtils.SetResult(Singleton<DataManager>.instance["Account"]["SelectedRoleIndex"], new Il2CppSystem.Int32() { m_value = Save.Settings.datas[count].Character }.BoxIl2CppObject());
            VariableUtils.SetResult(Singleton<DataManager>.instance["Account"]["SelectedElfinIndex"], new Il2CppSystem.Int32() { m_value = Save.Settings.datas[count].Elfin }.BoxIl2CppObject());
        }
    }
}