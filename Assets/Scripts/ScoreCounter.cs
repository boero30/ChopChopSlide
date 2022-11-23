using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public GameObject[] timer;
    public GameObject[] control;

    public TextMeshProUGUI time;
    public TextMeshProUGUI score;


    private void Start()
    {
        timer = GameObject.FindGameObjectsWithTag("timer");
        control = GameObject.FindGameObjectsWithTag("controlpoint");
    }
    void Update()
    {
        //time.text = timer.timeValue.ToString();
        //score.text = control.score.ToString();
    }
}
