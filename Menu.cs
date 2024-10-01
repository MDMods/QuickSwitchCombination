using System;
using System.Reflection;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using static QuickSwitchCombination.ConstantVariables;

namespace QuickSwitchCombination;

[RegisterTypeInIl2Cpp]
internal class Menu : MonoBehaviour
{
    public Menu(IntPtr intPtr) : base(intPtr)
    {
    }

    private static AssetBundle Ab { get; set; }
    internal static bool ShowMenu { get; set; } = false;

    private void Start()
    {
        if (Ab == null)
        {
            Ab = AssetBundle.LoadFromMemory(ReadEmbeddedFile("Menu.bundle"));
        }

        LoadGameObjects();
        SetMenu();
    }

    private void Update()
    {
        MenuPrefab.SetActive(ShowMenu);
    }

    private static byte[] ReadEmbeddedFile(string file)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream($"{Assembly.GetExecutingAssembly().GetName().Name}.{file}");
        var buffer = new byte[stream!.Length];
        stream.Read(buffer, 0, buffer.Length);

        return buffer;
    }

    private static void LoadGameObjects()
    {
        MenuPrefab = Instantiate(Ab.LoadAsset("Assets/Menu Canvas.prefab").Cast<GameObject>());
        MenuPrefab.SetActive(false);
        ConstantVariables.Minus = MenuPrefab.transform.GetChild(0).FindChild("Minus").gameObject;
        ConstantVariables.Plus = MenuPrefab.transform.GetChild(0).FindChild("Plus").gameObject;
        ContentTransform = MenuPrefab.transform.GetChild(0).FindChild("Scroll View").GetChild(0).GetChild(0);
    }

    private static void SetMenu()
    {
        ConstantVariables.Minus.AddComponent<Minus>();
        ConstantVariables.Plus.AddComponent<Plus>();

        for (var i = 0; i < Save.Settings.Data.Count; i++)
        {
            SetCombination(i);
        }
    }

    internal static void SetCombination(int count)
    {
        var combination = Instantiate(Ab.LoadAsset("Assets/Combination.prefab").Cast<GameObject>(), ContentTransform);

        combination.AddComponent<Count>();
        combination.GetComponent<Count>().count = count;

        combination.transform.GetChild(0).gameObject.AddComponent<Character>();

        combination.transform.GetChild(1).gameObject.AddComponent<Elfin>();

        combination.transform.GetChild(2).gameObject.AddComponent<Key>();
        combination.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = Save.Settings.Data[count].Key.ToString();

        combination.transform.GetChild(3).gameObject.AddComponent<Select>();
    }
}