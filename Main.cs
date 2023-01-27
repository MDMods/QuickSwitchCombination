using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;
using MelonLoader;
using System.IO;
using Tomlet;
using UnityEngine;
using UnityEngine.UI;
using static QuickSwitchCombination.Save;
using static UnhollowerRuntimeLib.ClassInjector;

namespace QuickSwitchCombination;

public class Main : MelonMod
{
    private static GameObject gameobject { get; set; }
    internal static int ClickIndex { get; set; } = 0;
    internal static bool SetKey { get; set; } = false;

    public override void OnInitializeMelon()
    {
        Load();
        RegisterTypeInIl2Cpp<Menu>();
        RegisterTypeInIl2Cpp<Minus>();
        RegisterTypeInIl2Cpp<Plus>();
        RegisterTypeInIl2Cpp<Count>();
        RegisterTypeInIl2Cpp<Character>();
        RegisterTypeInIl2Cpp<Elfin>();
        RegisterTypeInIl2Cpp<Key>();
        RegisterTypeInIl2Cpp<Select>();
        LoggerInstance.Msg("QuickSwitchCombination is loaded!");
    }

    public override void OnApplicationQuit()
    {
        File.WriteAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"), TomletMain.TomlStringFrom(Save.Settings));
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        if (sceneName == "UISystem_PC")
        {
            gameobject = new GameObject("QuickSwitchCombination");
            Object.DontDestroyOnLoad(gameobject);
            gameobject.AddComponent<Menu>();
        }
        else
        {
            Object.Destroy(gameobject);
        }
    }

    public override void OnGUI()
    {
        if (Input.anyKeyDown)
        {
            Event e = Event.current;
            if (e != null && e.isKey && e.keyCode != KeyCode.None)
            {
                for (int n = 0; n < Settings.datas.Count; n++)
                {
                    if (e.keyCode == Settings.datas[n].Key)
                    {
                        VariableUtils.SetResult(Singleton<DataManager>.instance["Account"]["SelectedRoleIndex"], new Il2CppSystem.Int32() { m_value = Settings.datas[n].Character }.BoxIl2CppObject());
                        VariableUtils.SetResult(Singleton<DataManager>.instance["Account"]["SelectedElfinIndex"], new Il2CppSystem.Int32() { m_value = Settings.datas[n].Elfin }.BoxIl2CppObject());
                    }
                }
                if (e.keyCode == Settings.MenuKey)
                {
                    Menu.ShowMenu = !Menu.ShowMenu;
                }
                if (SetKey)
                {
                    Data current = Settings.datas[ClickIndex];
                    current.Key = e.keyCode;
                    Settings.datas[ClickIndex] = current;
                    ConstantVariables.ContentTransform.GetChild(ClickIndex).GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = Settings.datas[ClickIndex].Key.ToString();
                    SetKey = false;
                }
            }
        }
    }
}