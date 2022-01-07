using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public bool overMidnight;

    private const int STARTINGTIME = 23;

    private int firstNumber;
    private float lastNumber;

    // Start is called before the first frame update
    void Start()
    {
        firstNumber = STARTINGTIME;
        lastNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lastNumber = lastNumber + Time.deltaTime;

        if (lastNumber > 9)
        {
            timerText.text = firstNumber + ":" + lastNumber.ToString("f0");
        }
        else
        {
            timerText.text = firstNumber + ":" + "0" + lastNumber.ToString("f0");
        }

        if (lastNumber > 60)
        {
            lastNumber = 0;
            firstNumber = firstNumber + 1;
        }


        if (firstNumber == 24)
        {
            overMidnight = true;
            timerText.text = "OVER MIDNIGHT";
        }
    }
}
