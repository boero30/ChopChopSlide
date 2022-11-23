using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public TextMeshProUGUI text;

    public bool timeout = false;

    public Controlpoint cp;
    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

        /*if(cp.lose == true)
        {
            timeValue -= 0;
        }*/
    }
    public void Lose()
    {
        Debug.Log("lose");
    }

    public void Win()
    {
        Debug.Log("win");
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }
        else if (timeToDisplay == 0)
        {
            Lose();
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //time.text = timer.timeValue.ToString();
    }
}


