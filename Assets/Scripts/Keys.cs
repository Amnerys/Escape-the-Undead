using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

    public static Keys Instance;
    public List<GameObject> keys;

    public bool AreKeysInactive()
    {
        foreach (GameObject keys in keys)
        {
            if (keys.gameObject != null)
            {
                return false;
            }
        }
        return true;
    }

    void Awake()
    {
        Instance = this;
    }
}
