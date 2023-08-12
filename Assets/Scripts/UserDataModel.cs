using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Cysharp.Threading.Tasks;

public class UserDataModel : MonoBehaviour
{
    public async UniTask Init()
    {
        var jsonString = await GetTitleDataAsync();
        var partyData = JsonUtility.FromJson<PartysArray>(jsonString);

        foreach(var p in partyData.party)
        {
            Debug.Log(p.name);
        }
    }

    public async void UpdateDisplayName(string name)// DisplayNameを更新
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = name
        };

        var responce = await PlayFabClientAPI.UpdateUserTitleDisplayNameAsync(request);

        if (responce.Error != null)
        {
            Debug.Log(responce.Error.GenerateErrorReport());
        }

        Debug.Log(name);
    }

    public async UniTask UpdateUserData()// ユーザーデータを更新
    {
        var request = new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>
            {
                { "Name", "Change" }
            }
        };

        var result = await PlayFabClientAPI.UpdateUserDataAsync(request);

        if(result.Error is null)
        {
            await GetUserData();
        }
    }

    private async UniTask<string> GetPlayerDisplayNameAsync()// DisplayNameを取得
    {
        var request = new GetPlayerProfileRequest();
        var responce = await PlayFabClientAPI.GetPlayerProfileAsync(request);

        if (responce.Error != null)
        {
            Debug.Log(responce.Error.GenerateErrorReport());
            return "";
        }
        return responce.Result.PlayerProfile.DisplayName;
    }

    private async UniTask GetUserData()// ユーザーデータを取得
    {
        var request = new GetUserDataRequest();
        var result = await PlayFabClientAPI.GetUserDataAsync(request);
        var log = result.Error is null ? result.Result.Data["Name"].Value
            : result.Error.GenerateErrorReport();
        Debug.Log(log);
    }

    private async UniTask<string> GetTitleDataAsync()// タイトルデータを取得
    {
        var request = new GetTitleDataRequest
        {
            Keys = new List<string> { "party" }
        };

        var responce = await PlayFabClientAPI.GetTitleDataAsync(request);

        if(responce.Error != null)
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

[System.Serializable]
public class PartyData
{
    public int id;
    public string name;
    public bool isHuman;
}
public class PartysArray
{
    public PartyData[] party;
}