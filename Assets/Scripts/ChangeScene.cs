using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    string SceneName = "";

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            if (!string.IsNullOrEmpty(SceneName))
                SceneManager.LoadScene(SceneName);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
