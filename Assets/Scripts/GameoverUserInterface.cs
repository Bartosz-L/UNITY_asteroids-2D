using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverUserInterface : MonoBehaviour
{
    [SerializeField]
    Text LastResultCounter;

    [SerializeField]
    Text RecordCounter;

	void Start ()
    {
        LastResultCounter.text = "Points: " + GameState.GetLastResult();
        RecordCounter.text = "Record: " + GameState.GetRecord();
	}
}
