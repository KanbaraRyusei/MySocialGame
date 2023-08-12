using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using System.Linq;

public class GachaModel : MonoBehaviour
{
    public async UniTask<string> DrawGachaAndGetResultName()
    {
        var request = new PurchaseItemRequest
        {
            StoreId = "GachaStore",
            ItemId = "bundle-gacha",
            VirtualCurrency = "MS",
            Price = 1
        };

        var response = await PlayFabClientAPI.PurchaseItemAsync(request);

        if (response.Error != null)
        {
            Debug.Log(response.Error.GenerateErrorReport());
            return null;
        }

        var getItems = response.Result.Items.Where(x => x.BundleParent != null);

        var items = getItems.ToArray();

        var result = items[0].DisplayName;

        Debug.Log(result);

        return result;
    }
}
