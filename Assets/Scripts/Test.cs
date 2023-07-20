using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Cysharp.Threading.Tasks;

public class Test : MonoBehaviour
{
    private PlayfabLogin _pl;

    async void Start()
    {
        _pl = GetComponent<PlayfabLogin>();

        if (await CustomIDLogin())
        {
            await _pl.GetUserData();
            await _pl.UpdateUserData();
        }
    }

    private async UniTask<bool> CustomIDLogin()
    {
        PlayFabSettings.staticSettings.TitleId = "1936E";
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "GettingStartedGuide",
            CreateAccount = true
        };
        var result = await PlayFabClientAPI.LoginWithCustomIDAsync(request);
        var log = result.Error is null ? result.Result.PlayFabId
            : result.Error.ErrorMessage;
        Debug.Log(log);
        return result.Error is null;
    }
}
