using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance == null)
                {
                    Debug.Log("Error: Could not find an instance of " + typeof(T));
                }
            }
            return _instance;
        }
    }

    public static T GuaranteedInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    _instance = new GameObject("Temp Instance of " + typeof(T), typeof(T)).GetComponent<T>();

                    // Problem during the creation, this should not happen
                    if (_instance == null)
                    {
                        Debug.LogError("Problem during the creation of " + typeof(T));
                    }
                }
            }
            return _instance;
        }
    }
}