using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UntilTheEnd.GameManager;

namespace UntilTheEnd
{
    public class Lobby : MonoBehaviour
    {
        void Start()
        {
            GameManager.instance.ChangeState(GameState.Lobby);

            // 테스트용
            //Loading.LoadScene(StringValues.Scene.login);
            Loading.LoadScene(StringValues.Scene.inGame);
        }

        void Update()
        {

        }
    }
}