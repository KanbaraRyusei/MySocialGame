using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;

public class TitleModel
{
    public async UniTask<string> TitleInit()
    {
        return await GetTitleDataAsync();
    }

    private async UniTask<string> GetTitleDataAsync()// タイトルデータを取得
    {
        var request = new GetTitleDataRequest
        {
            Keys = new List<string> { "party" }
        };

        var responce = await PlayFabClientAPI.GetTitleDataAsync(request);

        if (responce.Error != null)
        {
            Debug.Log(responce.Error.GenerateErrorReport());
        }
        else
        {
            return responce.Result.Data["party"];
        }

        return "";
    }
}
