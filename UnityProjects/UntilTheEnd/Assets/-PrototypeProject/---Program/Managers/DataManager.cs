using UnityEngine;

public class DataManager : DontDestroySingleton<DataManager>
{
    [SerializeField] private UserSettings _userSettings;
    [SerializeField] private GameVersionSettings _gameVersionSettings;

    void Start()
    {
        _userSettings = ScriptableObject.CreateInstance<UserSettings>();
        _userSettings.userNickName = string.Empty;

        _gameVersionSettings = ScriptableObject.CreateInstance<GameVersionSettings>();
        _gameVersionSettings.gameVersion = "v.1.0.0";
    }
}





// ��� ����
//UserSettings settings = new UserSettings();
//settings.userNickName = "John"; // �� �κп��� "set" �޼��尡 ȣ��˴ϴ�.

/*
1) ������ ���� : v. 1.1.0
��ȹ���� ū Ʋ�� ������ä ������ ����, ���� ����, �ܼ� ��Ÿ�� ������ �� ���ڰ� �ö󰣴�. 
������� ���� ��ȹ���� ���� �����Ǿ �߰��ߴٸ� v. 1.1.1 �� ���׷��̵� �ȴ�.

 
2) �ι�° ���� : v. 1.1.0
���� ����� ����� ������ ä ���ο� ����� �߰��Ǿ��� �� �����ȴ�.
������� �޸� ���ø����̼ǿ� �޸� ������ ����� �߰��Ѵٸ� v. 1.2.0 �� ���׷��̵� �ȴ�.

 
3) ù��° ���� : v. 1.1.0
����Ƽ ������ ���׷��̵� �Ǿ��� �� �����Ѵ�.
*/