using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : PunCallbackSingleton<NetworkManager>
{
    #region �α���
    public void LoginServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("��Ʈ��ũ ����o");
    }

    public override void OnConnectedToMaster() // ���̷�Ʈ�� �κ���� ����
    {
        base.OnConnectedToMaster();
        JoinLobby();
    }
    #endregion

    #region �κ�
    public void JoinLobby()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
            Debug.Log("�κ� ����");
        }
        else
        {
            Debug.Log("�̹� �κ� ���� ���Դϴ�.");
        }

        if (!PhotonNetwork.InRoom)
        {
            PhotonNetwork.LoadLevel(StringValues.Scene.preload);
        }
    }
    #endregion

    #region �� ����
    public void RoomOptions(Action callback)
    {
        if (!PhotonNetwork.InRoom)
        {
            Debug.Log("���� �����մϴ�.");

            RoomOptions option = new RoomOptions
            {
                MaxPlayers = 2,
                IsVisible = true,
                IsOpen = true
            };

            PhotonNetwork.JoinOrCreateRoom(StringValues.roomServer, option, TypedLobby.Default);
            StartCoroutine(WaitForJoinRoom(callback));
        }
        else
        {
            Debug.Log("�̹� �濡 ���� ���Դϴ�.");
        }
    }

    // �� �����̳� ���� �ϷḦ ��ٸ��� �ڷ�ƾ
    private IEnumerator WaitForJoinRoom(Action callback)
    {
        while (PhotonNetwork.InRoom == false)
        {
            yield return null;
        }

        callback?.Invoke();
    }
    #endregion

    #region ��
    // �� ��� ������Ʈ
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
    }

    // ���� ���ٸ� ����
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("�� ����");
    }

    // �� ����
    public override void OnJoinedRoom()
    {
        if (isRoomFull)
        {
            Debug.Log("�� �ο� �ʰ�, Lobby�� ���ư��ϴ�.");
            PhotonNetwork.LoadLevel(StringValues.Scene.lobby); // �κ� ������ �����̷�Ʈ
        }
        else
        {
            base.OnJoinedRoom();
            Debug.Log("�� ����");
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("üũ :: Failed to create room. ReturnCode: " + returnCode + ", Message: " + message);
        base.OnCreateRoomFailed(returnCode, message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning("üũ :: Failed to join room. ReturnCode: " + returnCode + ", Message: " + message);
        base.OnJoinRoomFailed(returnCode, message);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);

        switch (cause)
        {
            case DisconnectCause.DisconnectByClientLogic:
                break;
            case DisconnectCause.CustomAuthenticationFailed:
                break;
            case DisconnectCause.ApplicationQuit:
                break;
            default:
                Debug.Log("���� : " + cause.ToString());
                break;
        }
    }
    #endregion


    // ���ο� �÷��̾ �濡 ������ �� ȣ��Ǵ� �ݹ�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // 2��
        if (PhotonNetwork.CurrentRoom.PlayerCount >= PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            RoomFull();
        }
    }

    private bool isRoomFull = false;
    public void RoomFull()
    {
        isRoomFull = true;
        PhotonNetwork.CurrentRoom.IsOpen = false;
    }

    public void RoomNotFull()
    {
        if (PhotonNetwork.InRoom)
        {
            Debug.Log("���� �����ϴ�");
            PhotonNetwork.LeaveRoom();
        }
        if (PhotonNetwork.InLobby)
        {
            Debug.Log("�κ� �����ϴ�");
            PhotonNetwork.LeaveLobby();
        }
        SceneManager.instance.LoadScene(StringValues.Scene.preload);
    }

    // �г���
    private Dictionary<string, string> playerInfo = new Dictionary<string, string>();

    public void AddPlayerInfo(string nickname)
    {
        string playerId = PhotonNetwork.LocalPlayer.UserId;

        if (!playerInfo.ContainsKey(playerId))
        {
            playerInfo.Add(playerId, nickname);
            Debug.Log("���� �г��� : " + nickname);
        }
        else
        {
            Debug.Log("�г��� ���� : " + nickname);
        }
    }
}