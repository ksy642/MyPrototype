using UnityEngine;

namespace UntilTheEnd
{
    public class GameManager : DontDestroySingleton<GameManager>
    {
        [Header("FPS")]
        [SerializeField] private Color color = Color.red;
        private int _size = 25;
        private float _deltaTime = 0f;

        public enum GameState { None, Preload, Login, Lobby, InGame }
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

        //void Update()
        //{
        //    _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
        //}

        //private void _OnGUI()
        //{
        //    GUIStyle style = new GUIStyle();

        //    Rect rect = new Rect(1700, 20, Screen.width, Screen.height);
        //    style.alignment = TextAnchor.UpperLeft;
        //    style.fontSize = _size;
        //    style.normal.textColor = color;

        //    float ms = _deltaTime * 1000f;
        //    float fps = 1.0f / _deltaTime;
        //    string text = string.Format("{0:0.} FPS ({1:0.0} ms)", fps, ms);

        //    GUI.Label(rect, text, style);
        //}
    }
}