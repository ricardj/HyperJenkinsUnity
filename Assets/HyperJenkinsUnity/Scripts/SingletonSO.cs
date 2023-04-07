using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSO<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T get
    {
        get
        {
            T[] result = Resources.FindObjectsOfTypeAll<T>();
            if (result.Length == 0)
            {
                Debug.LogError("No singleton Scriptable object created");
                return null;
            }
            if (result.Length > 1)
            {
                Debug.LogError("Too many Singleton scriptable objects");
                return null;
            }
            _instance = result[0];
            _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;

            return _instance;
        }
    }
}
