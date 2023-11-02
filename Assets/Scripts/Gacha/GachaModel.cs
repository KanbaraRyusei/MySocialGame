using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using System.Linq;

public class GachaModel
{
    public async UniTask<string> DrawGachaAndGetResultName()
    {
        // �K�`���̃��N�G�X�g�̕ҏW�y�[�W
        // https://developer.playfab.com/ja-JP/1936E/economy/catalogs/Q2hhcmFjdGVyMDE%253d/bundles/YnVuZGxlLWdhY2hhMDE%253d/edit

        var request = new PurchaseItemRequest
        {
            StoreId = "GachaStore",
            ItemId = "bundle-gacha01",
            VirtualCurrency = "DD",
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
