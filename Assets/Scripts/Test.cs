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

        if (await CustomIDLogin()) // ���O�C���ł�����
        {
            // ���[�U�[�f�[�^���擾
            await _pl.GetUserData();
            // ���[�U�[�f�[�^���X�V
            await _pl.UpdateUserData();
        }
    }

    private async UniTask<bool> CustomIDLogin()
    {
        // �^�C�g��ID������
        PlayFabSettings.staticSettings.TitleId = "1936E";
        var request = new LoginWithCustomIDRequest
        {
            // �J�X�^��ID��ݒ�
            CustomId = "GettingStartedGuide",
            CreateAccount = true
        };
        // �񓯊��Ń��O�C��
        var result = await PlayFabClientAPI.LoginWithCustomIDAsync(request);

        // ���O�C�����������O���o��
        var log = result.Error is null ? result.Result.PlayFabId
            : result.Error.ErrorMessage;
        Debug.Log(log);
        return result.Error is null;
    }
}
