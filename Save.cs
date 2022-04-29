using System.Collections.Generic;
using System.IO;
using Tomlet;
using Tomlet.Attributes;
using UnityEngine;

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
        internal KeyCode ReloadKey;

        internal KeyCode MenuKey;

        internal List<Data> datas;

        public Config(KeyCode reloadkey, KeyCode menukey, List<Data> data)
        {
            ReloadKey = reloadkey;
            MenuKey = menukey;
            datas = data;
        }
    }

    public static class Save
    {
        private static Config DefaultConfig = new Config(KeyCode.F10, KeyCode.F11, new List<Data> { new Data(KeyCode.F12, "Little Devil", "Lilith") });
        public static Config Settings { get; set; }

        public static void Load()
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