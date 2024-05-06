using TMPro;

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

    private UserSettings _userSettings;

    // 장비창
    public GameObject equipmentPanel;
    public bool equipmentOpen = false;

    public bool TogglePanelESC(bool menuESC = false) // MouseLook.cs Update 동작 unlockCursorKey
    {
        if (!menuESC) // ESC 메뉴창이 꺼져있을 때
        {
            if (Input.GetKeyDown(KeyCode.E)) // E를 누르면 장비창을 켜, 근데 장비창이 켜져있으면 ESC 메뉴도 킬 수 있네? 막아야겠지?
            {
                equipmentOpen = !equipmentOpen;

                if (!equipmentOpen)
                {
                    equipmentPanel.gameObject.SetActive(false);
                }
                else
                {
                    equipmentPanel.gameObject.SetActive(true);
                }
            }

            panel_ESC.gameObject.SetActive(false);
            return true;
        }
        else // menuESC 켜질 예정
        {
            if (equipmentOpen)
            {
                equipmentPanel.gameObject.SetActive(false);
                equipmentOpen = false;
            }
            else
            {
                panel_ESC.gameObject.SetActive(true);
                return false;
            }

            return true;
        }
    }

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
        // 테스트용으로 U 키 눌렀을 때 다친 곳 나옴, 여기에 추가로 주사기 이런거 혹은 엘릭서 같은거 추가해서 먹으면 완치되게 만들어야되지않을까?
        // 5군데 지금 아픈데 그것도 심지어 랜덤으로 아픈거라 누적되는 방식이지만 같은곳 똑같이 아프게 될 수 있음
        // 이 부분도 생각해서 해야된다 ...

        // 일부로 강제로 다치게 하려고 테스트용으로 U 를 넣어둠
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