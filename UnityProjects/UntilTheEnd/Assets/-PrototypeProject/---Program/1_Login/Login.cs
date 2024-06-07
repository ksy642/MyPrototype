using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UntilTheEnd.GameManager;

namespace UntilTheEnd
{
    public class Login : MonoBehaviour
    {
        void Start()
        {
            GameManager.instance.ChangeState(GameState.Login);
        }
    }
}