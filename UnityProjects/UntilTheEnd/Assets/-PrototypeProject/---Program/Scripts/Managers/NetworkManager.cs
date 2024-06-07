using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntilTheEnd
{
    public class NetworkManager : PunCallbackSingleton<NetworkManager>
    {
        #region 로그인
        public void LoginServer()
        {
            PhotonNetwork.AutomaticallySyncScene = true;

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.Disconnect();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings();
                Debug.Log("로그인을 진행합니다.");
            }
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

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("로비에 성공적으로 입장했습니다.");
        }
        #endregion

        #region 방 생성
        public void RoomOptions(Action callback)
        {
            if (!PhotonNetwork.InRoom && PhotonNetwork.InLobby)
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

        #region 방
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
            if (_isRoomFull)
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
        #endregion

        #region OnCreateRoomFailed, OnJoinRoomFailed, OnDisconnected
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
            SceneManager.instance.LoadScene(StringValues.Scene.preload);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            PhotonNetwork.Disconnect();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            SceneManager.instance.LoadScene(StringValues.Scene.preload);

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

        private bool _isRoomFull = false;
        public void RoomFull()
        {
            _isRoomFull = true;
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }

        public void RoomNotFull()
        {
            if (PhotonNetwork.IsConnected)
            {
                _isRoomFull = false;
                PhotonNetwork.CurrentRoom.IsOpen = true;
                PhotonNetwork.Disconnect();
            }
            else
            {
                SceneManager.instance.LoadScene(StringValues.Scene.preload);
            }
        }






        // 닉네임 추후에 넣을 예정
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
}