using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Cysharp.Threading.Tasks;

public class Test : MonoBehaviour
{
    async void Start()
    {
        await CustomIDLogin();
    }

    private async UniTask CustomIDLogin()
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
    }
}
