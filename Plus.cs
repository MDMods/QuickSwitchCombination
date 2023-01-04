using System;
using UnhollowerRuntimeLib;
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
            var combination = Instantiate(Menu.ab.LoadAsset("Assets/Combination.prefab").Cast<GameObject>(), ConstantVariables.ContentTransform);
            Save.Settings.datas.Add(new Data(KeyCode.None, 0, -1));

            ClassInjector.RegisterTypeInIl2Cpp<Count>();
            combination.AddComponent<Count>();
            combination.GetComponent<Count>().count = Save.Settings.datas.Count - 1;

            ClassInjector.RegisterTypeInIl2Cpp<Character>();
            combination.transform.GetChild(0).gameObject.AddComponent<Character>();

            ClassInjector.RegisterTypeInIl2Cpp<Elfin>();
            combination.transform.GetChild(1).gameObject.AddComponent<Elfin>();
            ClassInjector.RegisterTypeInIl2Cpp<Key>();
            combination.transform.GetChild(2).gameObject.AddComponent<Key>();
        }
    }
}