using System.Collections.Generic;
using UnityEngine;

public class IInstanciable<T> : MonoBehaviour where T : IInstanciable<T>
{
    private static volatile T _instance = null;
    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = FindObjectOfType<T>();
                }
            }
            return _instance;
        }
    }
}