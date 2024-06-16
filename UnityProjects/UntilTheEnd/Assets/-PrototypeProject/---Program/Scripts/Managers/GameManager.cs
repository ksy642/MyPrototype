using UnityEngine;

namespace UntilTheEnd
{
    public class GameManager : DontDestroySingleton<GameManager>
    {
        public enum GameState { None, Preload, Avatar, Login, Lobby, InGame }
        [SerializeField] private GameState _gameState = GameState.None;

        public void ChangeState(GameState gameState)
        {
            if (_gameState == gameState)
            {
                Debug.LogFormat("중복실행 방지 : " + gameState);
                return;
            }

            Debug.LogFormat("Change State : " + gameState);
            _gameState = gameState;

            switch (gameState)
            {
                case GameState.Preload:
                    _OnPreload();
                    break;
                case GameState.Avatar:
                    _OnAvatar();
                    break;
                case GameState.Login:
                    _OnLogin();
                    break;
                case GameState.Lobby:
                    _OnLobby();
                    break;
                case GameState.InGame:
                    _OnInGame();
                    break;
                default:
                    break;
            }
        }

        private void _OnPreload()
        {
            Debug.Log("OnPreload");
        }

        private void _OnAvatar()
        {
            Debug.Log("OnAvatar");
        }

        private void _OnLogin()
        {
            Debug.Log("OnLogin");
        }

        private void _OnLobby()
        {
            Debug.Log("OnLobby");
        }

        private void _OnInGame()
        {
            Debug.Log("OnInGame");
        }
    }
}