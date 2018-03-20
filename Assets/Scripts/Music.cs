using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    void Start()
    {
        if (FindObjectsOfType<Music>().Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
