using System.Collections.Generic;
using System.IO;
using Tomlet;
using Tomlet.Attributes;
using UnityEngine;

namespace QuickSwitchCombination;

public class Data
{
    [TomlPrecedingComment("The character index")]
    internal int Character;

    [TomlPrecedingComment("The elfin index")]
    internal int Elfin;

    [TomlPrecedingComment("The shortcut key for switching character")]
    internal KeyCode Key;

    // For toml deserialization
    public Data()
    {
    }

    public Data(int character, int elfin, KeyCode key)
    {
        Character = character;
        Elfin = elfin;
        Key = key;
    }
}

public struct Config
{
    [TomlPrecedingComment("Menu for adding settings")]
    internal KeyCode MenuKey { get; set; } = KeyCode.F11;

    internal List<Data> Data { get; set; } = new() { new Data(11, 7, KeyCode.F12) };

    public Config()
    {
    }
}

public static class Save
{
    internal static Config Settings { get; private set; }

    internal static void Load()
    {
        if (!File.Exists(Path.Combine("UserData", "QuickSwitchCombination.cfg")))
        {
            var defaultConfig = TomletMain.TomlStringFrom(new Config());
            File.WriteAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"), defaultConfig);
        }

        var configs = File.ReadAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"));
        Settings = TomletMain.To<Config>(configs);
    }
}