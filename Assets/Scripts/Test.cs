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

        if (await CustomIDLogin()) // ログインできたら
        {
            // ユーザーデータを取得
            await _pl.GetUserData();
            // ユーザーデータを更新
            await _pl.UpdateUserData();
        }
    }

    private async UniTask<bool> CustomIDLogin()
    {
        // タイトルIDを入れる
        PlayFabSettings.staticSettings.TitleId = "1936E";
        var request = new LoginWithCustomIDRequest
        {
            // カスタムIDを設定
            CustomId = "GettingStartedGuide",
            CreateAccount = true
        };
        // 非同期でログイン
        var result = await PlayFabClientAPI.LoginWithCustomIDAsync(request);

        // ログインしたかログを出す
        var log = result.Error is null ? result.Result.PlayFabId
            : result.Error.ErrorMessage;
        Debug.Log(log);
        return result.Error is null;
    }
}
