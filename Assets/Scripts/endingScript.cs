using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingScript : MonoBehaviour
{
    public GameObject endingUI;

    public void end()
    {
        endingUI.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine("switchScene");
    }

    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
