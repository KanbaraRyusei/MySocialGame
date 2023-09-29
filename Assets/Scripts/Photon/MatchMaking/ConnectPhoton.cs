using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// Photonに接続するためのクラス
/// </summary>
public class ConnectPhoton : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private bool _isOfflineMode = false;

    private void Awake()
    {
        // オフラインでデバッグするとき用の分岐
        if(_isOfflineMode)
        {
            PhotonNetwork.OfflineMode = true;
            return;
        }
        // マスターサーバーに接続
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

        // ルームの設定をする
        var option = new RoomOptions();
        option.MaxPlayers = 2;
        option.CustomRoomProperties = initialProperty;
        option.CustomRoomPropertiesForLobby = propertyForLobby;

        // ルームに入る、無ければ作成する
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
