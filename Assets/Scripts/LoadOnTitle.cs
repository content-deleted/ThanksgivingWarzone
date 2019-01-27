using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnTitle : MonoBehaviour
{
    public TextMesh textMesh;
    public string nextSceneName;
	void Update () {
        if (Input.GetButton("Fire1")) {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextSceneName);
            textMesh.text = "LOADING...";
        }
    }
}
