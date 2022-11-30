using System.Collections.Generic;
using System.IO;
using Tomlet;
using Tomlet.Attributes;
using UnityEngine;

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit
    { }
}

namespace QuickSwitchCombination
{
    public struct Data
    {
        [TomlPrecedingComment("The shortcut key for switching character")]
        internal KeyCode Key;

        [TomlPrecedingComment("The character you want to switch")]
        internal string Character;

        [TomlPrecedingComment("The elfin you want to switch")]
        internal string Elfin;

        public Data(KeyCode key, string character, string elfin)
        {
            Key = key;
            Character = character;
            Elfin = elfin;
        }
    }

    public struct Config
    {
        [TomlPrecedingComment("Menu for adding settings (Still in developing)")]
        internal KeyCode MenuKey = KeyCode.F11;

        internal List<Data> datas { get; init; } = new() { new Data(KeyCode.F12, "Little Devil", "Lilith") };

        public Config()
        {
        }

        public Config(KeyCode menukey, List<Data> data)
        {
            MenuKey = menukey;
            datas = data;
        }
    }

    public static class Save
    {
        private static Config DefaultConfig = new();
        internal static Config Settings { get; set; }

        internal static void Load()
        {
            if (!File.Exists(Path.Combine("UserData", "QuickSwitchCombination.cfg")))
            {
                string defaultConfig = TomletMain.TomlStringFrom(DefaultConfig);
                File.WriteAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"), defaultConfig);
            }
            string Configs = File.ReadAllText(Path.Combine("UserData", "QuickSwitchCombination.cfg"));
            Settings = TomletMain.To<Config>(Configs);
        }
    }
}