using System.Collections;

using UnityEngine;

namespace UntilTheEnd
{
    public class UILogin : MonoBehaviour
    {
        public GameObject panel_MainGame; // 매인게임
        public GameObject[] menuButtons; // 매인게임2

        // 택1
        // Main Game
        public void MainGame()
        {
            panel_MainGame.gameObject.SetActive(true);
        }

        // Main Game2
        private bool _openMenu = false;
        public void MainGame2()
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
        public void HowtoPlay()
        {

        }

        // Options
        public void Options()
        {

        }

        // Credits
        public void Credits()
        {

        }

        // Quit Game
        public void QuitGame()
        {
            Application.Quit();
        }

        // Main Game Button Back
        public void Panel_MainGameBack()
        {
            panel_MainGame.gameObject.SetActive(false);
        }


        #region Main Game Button
        // Main Game Button Multi
        public void Panel_MainGameMulti()
        {
            // 방만드는식으로 진행이 될 예정...허나 먼저 포톤연결해서 들어가는식으로 진행을 하도록 하자...
            NetworkManager.instance.LoginServer(); // 다이렉트로 로비까지 진입ok
                                                   // 여기서 씬 넘기거나 방 같은거 만드는쪽으로 Canvas 만들어서 구성하고 거기서 Ready Go 하면 씬 넘어가게 설정가능

        }

        // Main Game Button Single
        public void Panel_MainGameSingle()
        {
            StartCoroutine(WaitTest());
        }

        IEnumerator WaitTest()
        {
            yield return new WaitForSeconds(2.0f);

            //SceneManager.instance.LoadScene("2_Lobby");
            SceneManager.instance.LoadScene("3_InGame");
        }
        #endregion
    }
}