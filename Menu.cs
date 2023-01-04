using System;
using System.Reflection;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;

namespace QuickSwitchCombination
{
    internal class Menu : MonoBehaviour
    {
        internal static AssetBundle ab { get; set; }

        public Menu(IntPtr intPtr) : base(intPtr)
        {
        }

        public static bool ShowMenu = false;

        private void Start()
        {
            if (ab == null)
            {
                ab = AssetBundle.LoadFromMemory(ReadEmbeddedFile("Menu.bundle"));
                LoadGameObjects();
                SetMenu();
            }
            else
            {
                LoadGameObjects();
                SetMenu();
            }
        }

        private void Update()
        {
            if (ShowMenu)
            {
                ConstantVariables.MenuPrefab.SetActive(true);
            }
            else
            {
                ConstantVariables.MenuPrefab.SetActive(false);
            }
        }

        private static byte[] ReadEmbeddedFile(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            byte[] buffer;
            using (var stream = assembly.GetManifestResourceStream($"{Assembly.GetExecutingAssembly().GetName().Name}.{file}"))
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
            }
            return buffer;
        }

        private static void LoadGameObjects()
        {
            ConstantVariables.MenuPrefab = Instantiate(ab.LoadAsset("Assets/Menu Canvas.prefab").Cast<GameObject>());
            ConstantVariables.MenuPrefab.SetActive(false);
            ConstantVariables.Reload = ConstantVariables.MenuPrefab.transform.GetChild(0).FindChild("Reload").gameObject;
            ConstantVariables.Plus = ConstantVariables.MenuPrefab.transform.GetChild(0).FindChild("Plus").gameObject;
            ConstantVariables.ContentTransform = ConstantVariables.MenuPrefab.transform.GetChild(0).FindChild("Scroll View").GetChild(0).GetChild(0);
        }

        private static void SetMenu()
        {
            ClassInjector.RegisterTypeInIl2Cpp<Reload>();
            ConstantVariables.Reload.AddComponent<Reload>();

            ClassInjector.RegisterTypeInIl2Cpp<Plus>();
            ConstantVariables.Plus.AddComponent<Plus>();

            SetCombination();
        }

        internal static void SetCombination()
        {
            for (int i = 0; i < Save.Settings.datas.Count; i++)
            {
                var combination = Instantiate(ab.LoadAsset("Assets/Combination.prefab").Cast<GameObject>(), ConstantVariables.ContentTransform);

                ClassInjector.RegisterTypeInIl2Cpp<Count>();
                combination.AddComponent<Count>();
                combination.GetComponent<Count>().count = i;

                ClassInjector.RegisterTypeInIl2Cpp<Character>();
                combination.transform.GetChild(0).gameObject.AddComponent<Character>();

                ClassInjector.RegisterTypeInIl2Cpp<Elfin>();
                combination.transform.GetChild(1).gameObject.AddComponent<Elfin>();

                ClassInjector.RegisterTypeInIl2Cpp<Key>();
                combination.transform.GetChild(2).gameObject.AddComponent<Key>();
                combination.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = Save.Settings.datas[i].Key.ToString();
            }
        }
    }
}