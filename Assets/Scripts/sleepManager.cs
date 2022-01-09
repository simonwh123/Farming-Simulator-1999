using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sleepManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("sleep");
    }
    IEnumerator sleep()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Farm");
    }
}
