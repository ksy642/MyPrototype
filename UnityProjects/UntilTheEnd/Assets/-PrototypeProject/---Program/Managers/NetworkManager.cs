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
        #region �α���
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
                Debug.Log("�α����� �����մϴ�.");
            }
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

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("�κ� ���������� �����߽��ϴ�.");
        }
        #endregion

        #region �� ����
        public void RoomOptions(Action callback)
        {
            if (!PhotonNetwork.InRoom && PhotonNetwork.InLobby)
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
            if (_isRoomFull)
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






        // �г��� ���Ŀ� ���� ����
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
}