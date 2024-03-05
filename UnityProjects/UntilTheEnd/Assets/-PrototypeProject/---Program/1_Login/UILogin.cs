using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;

public class UILogin : MonoBehaviour
{
    public GameObject panel_MainGame;

    void Start()
    {

    }

    // Main Game
    public void MainGame()
    {
        panel_MainGame.gameObject.SetActive(true);
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


    #region Main Game Button
    // Main Game Button Back
    public void Panel_MainGameBack()
    {
        panel_MainGame.gameObject.SetActive(false);
    }

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