using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameoverUI : MonoBehaviour
{
    [SerializeField]
    Text LastResultCounter;

    [SerializeField]
    Text RecordCounter;

    // Use this for initialization
    void Start ()
    {
        LastResultCounter.text = "Points: " + GameState.GetLastResult();
        RecordCounter.text = "Record: " + GameState.GetRecord();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
