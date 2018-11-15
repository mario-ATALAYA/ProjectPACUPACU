using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject OptionsMenu;

    private void Start()
    {
        OptionsMenu.SetActive(false);
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene("Game");
    }

    public void OptionsBtn()
    {
        OptionsMenu.SetActive(true);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
    public void CloseOptionMenu()
    {
        OptionsMenu.SetActive(false);
    }
}
