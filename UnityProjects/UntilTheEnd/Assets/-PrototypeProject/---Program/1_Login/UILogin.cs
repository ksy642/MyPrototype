using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UILogin : MonoBehaviour
{
    // 매인게임
    public GameObject panel_MainGame;

    // 매인게임2
    public GameObject[] menuButtons;

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
        // Do nothing
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