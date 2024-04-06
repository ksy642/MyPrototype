using TMPro;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TMP_InputField nicknameinput;
    public GameObject panel_ESC;

    // 다쳤을 때
    public GameObject[] hurtObjects;
    public Sprite hurtSprites_4;
    public Color hurtColor = Color.red;

    public bool TogglePanelESC(bool menuESC = false) // MouseLook.cs Update 동작
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


    // ESC 메뉴에서 나가기 버튼 눌렀을 때
    public void OnToLobby()
    {
        // 세이브 로드 설정해야함 !!
        SceneManager.instance.LoadScene("1_Login");
    }


    void Update()
    {
        // 테스트용으로 U 키 눌렀을 때 다친 곳 나옴
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (hurtSprites_4 != null)
            {
                int randomIndex = Random.Range(0, hurtObjects.Length);
                GameObject selectedHurtObject = hurtObjects[randomIndex];

                Image image = selectedHurtObject.GetComponent<Image>();
                if (image == null)
                {
                    image = selectedHurtObject.AddComponent<Image>();
                }
                image.sprite = hurtSprites_4;
                image.color = hurtColor;
                image.type = Image.Type.Filled;

                Animator animator = selectedHurtObject.GetComponent<Animator>();
                if (animator == null)
                {
                    animator = selectedHurtObject.AddComponent<Animator>();
                }
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("HurtSplit_1");
            }
        }
    }
}