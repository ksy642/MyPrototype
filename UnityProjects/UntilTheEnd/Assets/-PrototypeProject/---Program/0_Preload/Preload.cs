using Photon.Pun;
using UnityEngine;

public class Preload : MonoBehaviour
{
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            NetworkManager.instance.RoomNotFull();
        }
        else
        {
            SceneManager.instance.LoadScene("1_Login");
        }
    }
}
