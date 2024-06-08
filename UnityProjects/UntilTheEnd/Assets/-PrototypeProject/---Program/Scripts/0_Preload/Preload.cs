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
                StartCoroutine(DelayTime_1(3.0f));
                StartCoroutine(DelayTime_2(6.0f));
            }
        }

        IEnumerator DelayTime_1(float time)
        {
            yield return new WaitForSeconds(time);

            introPanel.SetActive(false);
            namePanel.SetActive(true);
            startPanel.SetActive(false);
        }

        IEnumerator DelayTime_2(float time)
        {
            yield return new WaitForSeconds(time);

            introPanel.SetActive(false);
            namePanel.SetActive(false);
            startPanel.SetActive(true);
        }

        public void OnClickSceneChanges()
        {
            Loading.LoadScene(StringValues.Scene.login);
        }
    }
}