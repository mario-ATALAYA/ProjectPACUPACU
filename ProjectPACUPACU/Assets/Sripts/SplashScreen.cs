using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    private float ChangeSceneCont;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeSceneCont += Time.deltaTime;
        if (ChangeSceneCont > 2)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
