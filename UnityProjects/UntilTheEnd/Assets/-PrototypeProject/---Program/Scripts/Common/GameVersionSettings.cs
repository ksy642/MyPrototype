using UnityEngine;

public class GameVersionSettings : ScriptableObject
{
    [SerializeField] private string _gameVersion;

    public string gameVersion
    {
        get
        {
            return _gameVersion;
        }
        set
        {
            _gameVersion = value;
        }
    }
}