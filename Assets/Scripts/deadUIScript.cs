using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadUIScript : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void restart()
    {
        SceneManager.LoadScene("Farm");
        GameObject.Find("DayCount").GetComponent<dayCountScript>().day = 1;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void onTwitter()
    {
        Application.OpenURL("https://twitter.com/daddysucc5000");
    }
}
