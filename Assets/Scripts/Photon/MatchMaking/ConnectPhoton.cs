using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// Photon�ɐڑ����邽�߂̃N���X
/// </summary>
public class ConnectPhoton : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private bool _isOfflineMode = false;

    private void Awake()
    {
        // �I�t���C���Ńf�o�b�O����Ƃ��p�̕���
        if(_isOfflineMode)
        {
            PhotonNetwork.OfflineMode = true;
            return;
        }
        // �}�X�^�[�T�[�o�[�ɐڑ�
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        var initialProperty = new ExitGames.Client.Photon.Hashtable
        {
            ["DisplayName"] = $"{PhotonNetwork.NickName} Room",
            ["Message"] = "Hello!"
        };

        var propertyForLobby = new[] { "DisplayName", "Message" };

        // ���[���̐ݒ������
        var option = new RoomOptions();
        option.MaxPlayers = 2;
        option.CustomRoomProperties = initialProperty;
        option.CustomRoomPropertiesForLobby = propertyForLobby;

        // ���[���ɓ���A������΍쐬����
        PhotonNetwork.JoinOrCreateRoom("Room", option, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed : " + message);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed : " + message);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed : " + message);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //base.OnDisconnected(cause);

        Debug.Log("Disconnected cause : " + cause.ToString());
    }
}
