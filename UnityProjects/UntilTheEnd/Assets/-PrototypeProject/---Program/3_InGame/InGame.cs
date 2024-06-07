using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UntilTheEnd.GameManager;

namespace UntilTheEnd
{
    public class InGame : MonoBehaviour
    {
        void Start()
        {
            GameManager.instance.ChangeState(GameState.InGame);
        }

        void Update()
        {

        }
    }
}