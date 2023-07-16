using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Test : MonoBehaviour
{
    async void Start()
    {
        PlayFabSettings.staticSettings.TitleId = "1936E";
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "GettingStartedGuide",
            CreateAccount = true
        };
        var result = await PlayFabClientAPI.LoginWithCustomIDAsync(request);
        var message = result.Error is null ? $"Login success! PlayFabID:{result.Result.PlayFabId}" : result.Error.GenerateErrorReport();
        Debug.Log(message);
    }
}
