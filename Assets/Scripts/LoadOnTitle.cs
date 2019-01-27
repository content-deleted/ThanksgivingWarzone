using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnTitle : MonoBehaviour
{
    public TextMesh textMesh;
    public string nextSceneName;
	void Update () {
        if (Input.anyKeyDown) {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextSceneName);
            textMesh.text = "LOADING...";
        }
    }
}
