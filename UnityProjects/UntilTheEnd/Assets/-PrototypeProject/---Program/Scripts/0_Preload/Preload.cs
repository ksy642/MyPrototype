using System.Collections;
using Photon.Pun;
using UnityEngine;
using static UntilTheEnd.GameManager;

namespace UntilTheEnd
{
    public class Preload : MonoBehaviour
    {
        public GameObject introPanel;
        public GameObject namePanel;
        public GameObject startPanel;

        void Start()
        {
            GameManager.instance.ChangeState(GameState.Preload);

            if (PhotonNetwork.IsConnected)
            {
                NetworkManager.instance.RoomNotFull();
            }
            else
            {
                StartCoroutine(StaticCoroutines.DelayedAction(3.0f, () =>
                {
                    introPanel.SetActive(false);
                    namePanel.SetActive(true);
                    startPanel.SetActive(false);
                }));

                StartCoroutine(StaticCoroutines.DelayedAction(6.0f, () =>
                {
                    introPanel.SetActive(false);
                    namePanel.SetActive(false);
                    startPanel.SetActive(true);
                }));
            }
        }

        public void OnClickSceneChanges()
        {
            Loading.LoadScene(StringValues.Scene.login);
        }
    }
}