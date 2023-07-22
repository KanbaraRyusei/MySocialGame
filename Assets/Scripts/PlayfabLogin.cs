using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Cysharp.Threading.Tasks;

public class PlayfabLogin : MonoBehaviour
{
    public async UniTask GetUserData()// ���[�U�[�f�[�^���擾
    {
        var request = new GetUserDataRequest();
        var result = await PlayFabClientAPI.GetUserDataAsync(request);
        var log = result.Error is null ? result.Result.Data["Name"].Value
            : result.Error.GenerateErrorReport();
        Debug.Log(log);
    }

    public async UniTask UpdateUserData()// ���[�U�[�f�[�^���X�V
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
}
