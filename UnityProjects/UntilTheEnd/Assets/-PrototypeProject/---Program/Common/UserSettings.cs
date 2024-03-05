using UnityEngine;

public class UserSettings : ScriptableObject
{
    [SerializeField] private string _userNickName;

    public string userNickName
    {
        get
        {
            return _userNickName;
        }
        set
        {
            _userNickName = value;
        }
    }
}