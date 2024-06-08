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
            // �游��½����� ������ �� ����...�㳪 ���� ���濬���ؼ� ���½����� ������ �ϵ��� ����...
            NetworkManager.instance.LoginServer(); // ���̷�Ʈ�� �κ���� ����ok
                                                   // ���⼭ �� �ѱ�ų� �� ������ ����������� Canvas ���� �����ϰ� �ű⼭ Ready Go �ϸ� �� �Ѿ�� ��������

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