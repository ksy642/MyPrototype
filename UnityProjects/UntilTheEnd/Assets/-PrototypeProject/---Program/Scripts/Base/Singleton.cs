using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object _instanceLock = new object();

    public static T instance
    {
        get
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        var resource = Resources.Load<GameObject>(typeof(T).ToString());
                        _instance = resource?.GetComponent<T>();

                        if (_instance == null)
                        {
                            GameObject go = new GameObject(typeof(T).ToString());
                            _instance = go.AddComponent<T>();
                        }

                        DontDestroyOnLoad(instance.gameObject);
                    }
                }
                return _instance;
            }
        }
    }
}

public class DontDestroySingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}