using System.IO;
using System.Linq;
using Assets.Scripts.Database;
using MelonLoader;
using Tomlet;
using UnityEngine;
using UnityEngine.UI;
using static QuickSwitchCombination.Save;
using static UnhollowerRuntimeLib.ClassInjector;

namespace QuickSwitchCombination;

public class Main : MelonMod
{
    private static GameObject GameObject { get; set; }
    internal static int ClickIndex { get; set; } = 0;
    internal static bool SetKey { get; set; }

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

    public override void OnDeinitializeMelon()
    {
        File.WriteAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"), TomletMain.TomlStringFrom(Settings));
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        if (sceneName == "UISystem_PC")
        {
            GameObject = new GameObject("QuickSwitchCombination");
            Object.DontDestroyOnLoad(GameObject);
            GameObject.AddComponent<Menu>();
        }
        else
        {
            Object.Destroy(GameObject);
        }
    }

    public override void OnGUI()
    {
        if (!Input.anyKeyDown) return;
        var e = Event.current;
        if (e.isKey && e.keyCode != KeyCode.None)
        {
            if (e.keyCode == Settings.MenuKey)
            {
                Menu.ShowMenu = !Menu.ShowMenu;
                return;
            }

            if (SetKey)
            {
                Settings.Data[ClickIndex].Key = e.keyCode;
                ConstantVariables.ContentTransform.GetChild(ClickIndex).GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text =
                    Settings.Data[ClickIndex].Key.ToString();
                SetKey = false;
                return;
            }

            var combination = Settings.Data.FirstOrDefault(x => x.Key == e.keyCode);
            if (combination is null) return;
            DataHelper.selectedRoleIndex = combination.Character;
            DataHelper.selectedElfinIndex = combination.Elfin;
        }
    }
}