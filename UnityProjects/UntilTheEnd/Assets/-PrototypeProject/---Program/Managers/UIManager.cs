using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TMP_InputField nicknameinput;
    public GameObject panel_ESC;

    private UserSettings _userSettings;

    public void OnClickNickname()
    {
        string nickname = nicknameinput.text;

        if (string.IsNullOrWhiteSpace(nickname))
        {
            nickname = "UserName " + Random.Range(1, 10000);
        }

        PlayerPrefs.SetString("Nickname", nickname);
        _userSettings.userNickName = nickname;
        //PhotonNetwork.NickName = nickname;
        Debug.Log(" 닉네임  : " + nickname + " 저장 완료");
    }

    // MouseLook.cs Update 동작
    public bool TogglePanelESC(bool menuESC = false)
    {
        if (!menuESC) // 기본값 false 즉, 여기부터 시작
        {
            panel_ESC.gameObject.SetActive(false);
            return true;
        }
        else // true
        {
            panel_ESC.gameObject.SetActive(true);
            return false;
        }
    }

    // ESC 메뉴에서 나가기 버튼 눌렀을 때
    public void OnToLobby()
    {
        // 세이브 로드 설정해야함 !!
        SceneManager.instance.LoadScene("1_Login");
    }
}