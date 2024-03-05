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





// 사용 예시
//UserSettings settings = new UserSettings();
//settings.userNickName = "John"; // 이 부분에서 "set" 메서드가 호출됩니다.

/*
1) 마지막 숫자 : v. 1.1.0
기획서의 큰 틀은 유지한채 자잘한 오류, 누락 사항, 단순 오타를 수정할 때 숫자가 올라간다. 
예를들어 기존 기획서에 얼럿이 누락되어서 추가했다면 v. 1.1.1 로 업그레이드 된다.

 
2) 두번째 숫자 : v. 1.1.0
기존 내용과 기능은 유지한 채 새로운 기능이 추가되었을 때 수정된다.
예를들어 메모 애플리케이션에 메모 폴더링 기능을 추가한다면 v. 1.2.0 로 업그레이드 된다.

 
3) 첫번째 숫자 : v. 1.1.0
유니티 버전의 업그레이드 되었을 때 수정한다.
*/