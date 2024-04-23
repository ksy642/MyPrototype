using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : PunCallbackSingleton<NetworkManager>
{
    #region 로그인
    public void LoginServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("네트워크 연결o");
    }

    public override void OnConnectedToMaster() // 다이렉트로 로비까지 진입
    {
        base.OnConnectedToMaster();
        JoinLobby();
    }
    #endregion

    #region 로비
    public void JoinLobby()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
            Debug.Log("로비 진입");
        }
        else
        {
            Debug.Log("이미 로비에 참여 중입니다.");
        }

        if (!PhotonNetwork.InRoom)
        {
            PhotonNetwork.LoadLevel(StringValues.Scene.preload);
        }
    }
    #endregion

    #region 방 생성
    public void RoomOptions(Action callback)
    {
        if (!PhotonNetwork.InRoom)
        {
            Debug.Log("방을 생성합니다.");

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
            Debug.Log("이미 방에 참여 중입니다.");
        }
    }

    // 방 입장이나 생성 완료를 기다리는 코루틴
    private IEnumerator WaitForJoinRoom(Action callback)
    {
        while (PhotonNetwork.InRoom == false)
        {
            yield return null;
        }

        callback?.Invoke();
    }
    #endregion

    #region 룸
    // 방 목록 업데이트
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
    }

    // 방이 없다면 생성
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("방 생성");
    }

    // 방 접속
    public override void OnJoinedRoom()
    {
        if (isRoomFull)
        {
            Debug.Log("방 인원 초과, Lobby로 돌아갑니다.");
            PhotonNetwork.LoadLevel(StringValues.Scene.lobby); // 로비 씬으로 리다이렉트
        }
        else
        {
            base.OnJoinedRoom();
            Debug.Log("방 참가");
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("체크 :: Failed to create room. ReturnCode: " + returnCode + ", Message: " + message);
        base.OnCreateRoomFailed(returnCode, message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning("체크 :: Failed to join room. ReturnCode: " + returnCode + ", Message: " + message);
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
                Debug.Log("상태 : " + cause.ToString());
                break;
        }
    }
    #endregion


    // 새로운 플레이어가 방에 입장할 때 호출되는 콜백
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // 2명
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
            Debug.Log("방을 떠납니다");
            PhotonNetwork.LeaveRoom();
        }
        if (PhotonNetwork.InLobby)
        {
            Debug.Log("로비를 떠납니다");
            PhotonNetwork.LeaveLobby();
        }
        SceneManager.instance.LoadScene(StringValues.Scene.preload);
    }

    // 닉네임
    private Dictionary<string, string> playerInfo = new Dictionary<string, string>();

    public void AddPlayerInfo(string nickname)
    {
        string playerId = PhotonNetwork.LocalPlayer.UserId;

        if (!playerInfo.ContainsKey(playerId))
        {
            playerInfo.Add(playerId, nickname);
            Debug.Log("현재 닉네임 : " + nickname);
        }
        else
        {
            Debug.Log("닉네임 저장 : " + nickname);
        }
    }
}