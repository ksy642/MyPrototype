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
        Debug.Log(" �г���  : " + nickname + " ���� �Ϸ�");
    }

    // MouseLook.cs Update ����
    public bool TogglePanelESC(bool menuESC = false)
    {
        if (!menuESC) // �⺻�� false ��, ������� ����
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

    // ESC �޴����� ������ ��ư ������ ��
    public void OnToLobby()
    {
        // ���̺� �ε� �����ؾ��� !!
        SceneManager.instance.LoadScene("1_Login");
    }
}