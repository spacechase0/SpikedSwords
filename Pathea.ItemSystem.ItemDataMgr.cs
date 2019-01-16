using Harmony;
using Pathea.ItemSystem;
using spacechase0.MiniModLoader.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SpikedSwords
{
    [HarmonyPatch(typeof(ItemDataMgr))]
    [HarmonyPatch("OnLoad")]
    public static class LoadHook
    {
        public static void Postfix( List<ItemBaseConfData> ___itemBaseList, List<EquipmentItemConfData> ___equipmentDataList )
        {
            Log.Debug("Doing item database stuff");

            ItemBaseConfData bronzeSwordBase = null, ironSwordBase = null;
            foreach ( var itemBase in ___itemBaseList )
            {
                if (itemBase.NameID == 270008)
                    bronzeSwordBase = itemBase;
                else if (itemBase.NameID == 270010)
                    ironSwordBase = itemBase;
                if (bronzeSwordBase != null && ironSwordBase != null)
                    break;
            }
            /*
            var bronzeSwordBase = ___itemBaseList.Where(p => p.NameID == 270008).First();
            var ironSwordBase = ___itemBaseList.Where(p => p.NameID == 270010).First();
            */
            
            var spikedBronzeSwordBase = Util.Duplicate(bronzeSwordBase);
            spikedBronzeSwordBase.ID = spikedBronzeSwordBase.ItemFunctionID = 1000000000;
            spikedBronzeSwordBase.NameID = Mod.SpikedBronzeSword_Name;
            spikedBronzeSwordBase.BuyPrice *= 5;
            spikedBronzeSwordBase.SellPrice.id0 *= 5;
            ___itemBaseList.Add(spikedBronzeSwordBase);

            var spikedIronSwordBase = Util.Duplicate(ironSwordBase);
            spikedIronSwordBase.ID = spikedIronSwordBase.ItemFunctionID = 1000000001;
            spikedIronSwordBase.NameID = Mod.SpikedIronSword_Name;
            spikedIronSwordBase.BuyPrice *= 5;
            spikedIronSwordBase.SellPrice.id0 *= 5;
            ___itemBaseList.Add(spikedIronSwordBase);

            EquipmentItemConfData bronzeSword = null, ironSword = null;
            foreach (var itemEquipment in ___equipmentDataList)
            {
                if (itemEquipment.id == bronzeSwordBase.ID)
                    bronzeSword = itemEquipment;
                else if (itemEquipment.id == ironSwordBase.ID)
                    ironSword = itemEquipment;
                if (bronzeSword != null && ironSword != null)
                    break;
            }
            /*
            var bronzeSword = ___equipmentDataList.Where(p => p.id == bronzeSwordBase.ID).First();
            var ironSword = ___equipmentDataList.Where(p => p.id == ironSwordBase.ID).First();
            */

            var spikedBronzeSword = Util.Duplicate(bronzeSword);
            spikedBronzeSword.id = 1000000000;
            spikedBronzeSword.critical = 0.5f;
            ___equipmentDataList.Add(spikedBronzeSword);

            var spikedIronSword = Util.Duplicate(ironSword);
            spikedIronSword.id = 1000000001;
            spikedIronSword.critical = 0.5f;
            ___equipmentDataList.Add(spikedIronSword);
        }
    }
}
