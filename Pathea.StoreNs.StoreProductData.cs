using Harmony;
using Pathea.ItemSystem;
using Pathea.ModuleNs;
using Pathea.StoreNs;
using spacechase0.MiniModLoader.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpikedSwords
{
    [HarmonyPatch(typeof(StoreProductData))]
    [HarmonyPatch("LoadDataBase")]
    public static class ShopProductHook
    {
        public static void Postfix(List<StoreProductData> ___refDataDic)
        {
            Log.Debug("Doing product stuff");
            ___refDataDic.Add(new StoreProductData()
            {
                productId = 1000000000,
                itemId = 1000000000,
                currency_itemId = -1,
                exchangeRateData = new DoubleInt(Module<ItemDataMgr>.Self.GetItemBaseData(1000000000).BuyPrice, 1),
                reqMissionId = new int[] { -1 },
                isLimited = false,
            });
            ___refDataDic.Add(new StoreProductData()
            {
                productId = 1000000001,
                itemId = 1000000001,
                currency_itemId = -1,
                exchangeRateData = new DoubleInt(Module<ItemDataMgr>.Self.GetItemBaseData(1000000001).BuyPrice, 1),
                reqMissionId = new int[] { -1 },
                isLimited = false,
            });
        }
    }
}
