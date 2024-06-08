using System.Collections;

using UnityEngine;

namespace UntilTheEnd
{
    public class UILogin : MonoBehaviour
    {
        public GameObject[] menuButtons;
        private bool _openMenu = false;

        public void OnClickMainGame()
        {
            _openMenu = !_openMenu;

            if (_openMenu)
            {
                foreach (var menuButtons in menuButtons)
                {
                    menuButtons.gameObject.SetActive(true);
                }
            }
            else
            {
                foreach (var menuButtons in menuButtons)
                {
                    menuButtons.gameObject.SetActive(false);
                }
            }
        }

        // How to Play
        public void OnClickHowToPlay()
        {

        }

        // Options
        public void OnClickOptions()
        {

        }

        // Credits
        public void OnClickCredits()
        {

        }

        // Quit Game
        public void OnClickQuitGame()
        {
            Application.Quit();
        }

        #region Main Game Button
        // Main Game Button Multi
        public void Panel_MainGameMulti()
        {
            // 방만드는식으로 진행이 될 예정...허나 먼저 포톤연결해서 들어가는식으로 진행을 하도록 하자...
            NetworkManager.instance.LoginServer(); // 다이렉트로 로비까지 진입ok
            // 여기서 씬 넘기거나 방 같은거 만드는쪽으로 Canvas 만들어서 구성하고 거기서 Ready Go 하면 씬 넘어가게 설정가능

        }

        // Main Game Button Single :: 먼저 싱글부터 개발
        public void Panel_MainGameSingle()
        {
            StartCoroutine(WaitTest());
        }

        IEnumerator WaitTest()
        {
            yield return new WaitForSeconds(2.0f);

            Loading.LoadScene(StringValues.Scene.inGame);
        }
        #endregion
    }
}