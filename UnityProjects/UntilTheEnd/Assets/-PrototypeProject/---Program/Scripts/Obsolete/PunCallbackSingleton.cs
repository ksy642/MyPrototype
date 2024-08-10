using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PunCallbackSingleton<T> : MonoBehaviourPunCallbacks where T : MonoBehaviour
{
    private static T _instance;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                //_instance = FindObjectOfType<T>();
                _instance = FindFirstObjectByType<T>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}