using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static QuickSwitchCombination.ConstantVariables;

namespace QuickSwitchCombination
{
    internal class Menu : MonoBehaviour
    {
        internal static AssetBundle ab { get; set; }
        internal static bool ShowMenu { get; set; } = false;

        public Menu(IntPtr intPtr) : base(intPtr)
        {
        }

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
                MenuPrefab.SetActive(true);
            }
            else
            {
                MenuPrefab.SetActive(false);
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

        private void LoadGameObjects()
        {
            MenuPrefab = Instantiate(ab.LoadAsset("Assets/Menu Canvas.prefab").Cast<GameObject>());
            MenuPrefab.SetActive(false);
            ConstantVariables.Minus = MenuPrefab.transform.GetChild(0).FindChild("Minus").gameObject;
            ConstantVariables.Plus = MenuPrefab.transform.GetChild(0).FindChild("Plus").gameObject;
            ContentTransform = MenuPrefab.transform.GetChild(0).FindChild("Scroll View").GetChild(0).GetChild(0);
        }

        private void SetMenu()
        {
            ConstantVariables.Minus.AddComponent<Minus>();
            ConstantVariables.Plus.AddComponent<Plus>();

            for (int i = 0; i < Save.Settings.datas.Count; i++)
            {
                SetCombination(i);
            }
        }

        internal static void SetCombination(int count)
        {
            var combination = Instantiate(ab.LoadAsset("Assets/Combination.prefab").Cast<GameObject>(), ContentTransform);

            combination.AddComponent<Count>();
            combination.GetComponent<Count>().count = count;

            combination.transform.GetChild(0).gameObject.AddComponent<Character>();

            combination.transform.GetChild(1).gameObject.AddComponent<Elfin>();

            combination.transform.GetChild(2).gameObject.AddComponent<Key>();
            combination.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = Save.Settings.datas[count].Key.ToString();

            combination.transform.GetChild(3).gameObject.AddComponent<Select>();
        }
    }
}