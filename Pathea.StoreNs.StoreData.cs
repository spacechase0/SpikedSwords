using Harmony;
using Pathea.StoreNs;
using spacechase0.MiniModLoader.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpikedSwords
{
    [HarmonyPatch(typeof(StoreData))]
    [HarmonyPatch("LoadDataBase")]
    public static class ShopHook
    {
        public static void Postfix()
        {
            Log.Debug("Doing store stuff");
            var store = StoreData.GetRefData(5);

            var newItem1 = new SaleProductData()
            {
                chance = 1,
                productId = 1000000000,
                count = 1,
            };
            var newItem2 = new SaleProductData()
            {
                chance = 1,
                productId = 1000000001,
                count = 1,
            };
            Array.Resize(ref store.generalProductData, store.generalProductData.Length + 2);
            store.generalProductData[store.generalProductData.Length - 2] = newItem1;
            store.generalProductData[store.generalProductData.Length - 1] = newItem2;
        }
    }
}
