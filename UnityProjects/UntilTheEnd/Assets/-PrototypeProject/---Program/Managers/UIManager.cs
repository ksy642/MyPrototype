using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TMP_InputField nicknameinput;
    public GameObject panel_ESC;

    // ������ ��
    public GameObject[] hurtObjects;
    public Sprite hurtSprites_4;
    public Color hurtColor = Color.red;

    private UserSettings _userSettings;

    // ���â
    public GameObject equipmentPanel;
    public bool equipmentOpen = false;

    public bool TogglePanelESC(bool menuESC = false) // MouseLook.cs Update ���� unlockCursorKey
    {
        if (!menuESC) // ESC �޴�â�� �������� ��
        {
            if (Input.GetKeyDown(KeyCode.E)) // E�� ������ ���â�� ��, �ٵ� ���â�� ���������� ESC �޴��� ų �� �ֳ�? ���ƾ߰���?
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
        else // menuESC ���� ����
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
        Debug.Log(" �г���  : " + nickname + " ���� �Ϸ�");
    }


    // ESC �޴����� ������ ��ư ������ ��
    public void OnToLobby()
    {
        // ���̺� �ε� �����ؾ��� !!
        SceneManager.instance.LoadScene("1_Login");
    }


    void Update()
    {
        // �׽�Ʈ������ U Ű ������ �� ��ģ �� ����, ���⿡ �߰��� �ֻ�� �̷��� Ȥ�� ������ ������ �߰��ؼ� ������ ��ġ�ǰ� �����ߵ���������?
        // 5���� ���� ���µ� �װ͵� ������ �������� ���°Ŷ� �����Ǵ� ��������� ������ �Ȱ��� ������ �� �� ����
        // �� �κе� �����ؼ� �ؾߵȴ� ...

        // �Ϻη� ������ ��ġ�� �Ϸ��� �׽�Ʈ������ U �� �־��
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