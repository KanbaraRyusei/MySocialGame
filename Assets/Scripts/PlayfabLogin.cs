using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Cysharp.Threading.Tasks;

public class PlayfabLogin : MonoBehaviour
{
    public bool WasLogin => _wasLogin;

    [SerializeField]
    private string _debugId;

    private bool _wasLogin = false;

    private void Awake()
    {
        CustomIDLogin().Forget();
    }

    private async UniTask CustomIDLogin()
    {
        // タイトルIDを入れる
        PlayFabSettings.staticSettings.TitleId = "1936E";
        var request = new LoginWithCustomIDRequest
        {
            // カスタムIDを設定
            CustomId = _debugId + SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        // 非同期でログイン
        var result = await PlayFabClientAPI.LoginWithCustomIDAsync(request);

        _wasLogin = result.Error is null;

        // ログインしたかログを出す
        var log = _wasLogin ? result.Result.PlayFabId
            : result.Error.ErrorMessage;
        Debug.Log(log);
    }
}
