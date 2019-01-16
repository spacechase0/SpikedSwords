using Harmony;
using Pathea.CompoundSystem;
using spacechase0.MiniModLoader.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SpikedSwords
{
    [HarmonyPatch(typeof(CompoundManager))]
    [HarmonyPatch("GetSourceData")]
    public static class RecipeHook
    {
        public static void Postfix(List<CompoundItemData> ___sourceData)
        {
            Log.Debug("Doing recipe stuff");
            CompoundItemData spikedPracticeSword = null;
            foreach ( var recipe in ___sourceData )
            {
                if ( recipe.ID == 22 )
                {
                    spikedPracticeSword = recipe;
                    break;
                }
            }

            var spikedBronzeSword = Util.Duplicate(spikedPracticeSword);
            spikedBronzeSword.ID = 1000000000;
            spikedBronzeSword.NameID = 1000000000;
            spikedBronzeSword.ItemID = 1000000000;
            spikedBronzeSword.BookId = 1000000000;
            spikedBronzeSword.Unlock_Level = 1;
            spikedBronzeSword.RequireItem1 = 1001003; // Practice sword -> bronze sword
            spikedBronzeSword.RequireItemNum2 *= 5;
            spikedBronzeSword.RequireItemNum3 *= 5;
            ___sourceData.Add(spikedBronzeSword);

            var spikedIronSword = Util.Duplicate(spikedPracticeSword);
            spikedIronSword.ID = 1000000001;
            spikedIronSword.NameID = 1000000001;
            spikedIronSword.ItemID = 1000000001;
            spikedIronSword.BookId = 1000000001;
            spikedIronSword.Unlock_Level = 2;
            spikedIronSword.RequireItem1 = 1001004; // Practice sword -> Iron sword 
            spikedIronSword.RequireItem2 = 4000211; // Spines -> Welding Rod
            spikedIronSword.RequireItem3 = 4000269; // Resin -> Hardened Clay
            ___sourceData.Add(spikedIronSword);
        }
    }
}
