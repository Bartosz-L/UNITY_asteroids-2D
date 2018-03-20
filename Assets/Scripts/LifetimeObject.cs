using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeObject : MonoBehaviour
{
    [SerializeField]
    float Lifetime = 5f;

	void Start ()
    {
        Destroy(gameObject, Lifetime);
	}
}
 