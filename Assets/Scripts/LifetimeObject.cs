using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeObject : MonoBehaviour
{
    [SerializeField]
    float Lifetime = 3f;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, Lifetime);
	}
}
