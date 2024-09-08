using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected static T _instance = null;
    private static bool _isDestroy = false;

    public static T Instance
    {
        get
        {
            if (_isDestroy)
            {
                return null;
            }

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(T)) as T;

                if (_instance == null)
                {
                    _instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();

                    if (_instance == null)
                    {
                        // Error when an instance cannot be created.
                        Debug.LogError("Singleton::Problem during the creation of " + typeof(T).ToString());
                    }
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
        }
    }

    /// <summary>
    /// Clear GameObject
    /// </summary>
    private void OnDestroy()
    {
        Release();
    }

    private void Release()
    {
        if (_instance != null)
        {
            Debug.LogFormat("Singleton Release : {0}", name);
            Destroy(_instance.gameObject);
            _instance = null;
        }
        else
        {
            Debug.LogFormat("Singleton Release null : {0}", name);
        }
    }
}
