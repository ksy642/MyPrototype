using UnityEngine;
using static UntilTheEnd.GameManager;

namespace UntilTheEnd
{
    public class CheckState : MonoBehaviour
    {
        public GameState thisSceneStartState = GameState.None;

        void Start()
        {
            GameManager.instance.ChangeState(thisSceneStartState);
        }
    }
}