using Harmony;
using spacechase0.MiniModLoader.Api;
using spacechase0.MiniModLoader.Api.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpikedSwords
{
    public class Mod : IMod
    {
        public static int SpikedBronzeSword_Name;
        public static int SpikedIronSword_Name;

        public override void AfterModsLoaded()
        {
            SpikedBronzeSword_Name = Translations.Register(new Translation() { English = "Spiked Bronze Sword" });
            SpikedIronSword_Name = Translations.Register(new Translation() { English = "Spiked Iron Sword" });

            var harmony = HarmonyInstance.Create("spacechase0.SpikedSwords");
            harmony.PatchAll();
        }
    }
}
