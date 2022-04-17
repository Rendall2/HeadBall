using Photon.Pun;
using UnityEngine;

public class SingletonPun<T> : MonoBehaviourPunCallbacks where T : MonoBehaviourPunCallbacks
{
    private static object _lock = new object();
    private static T _instance;

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null) _instance = (T) FindObjectOfType(typeof(T));

                return _instance;
            }
        }
    }
}