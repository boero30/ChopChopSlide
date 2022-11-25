using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool PauseOpen = false;
    public GameObject PauseUI;
    public Button pause;
    void Start()
    {
        Button btn = pause.GetComponent<Button>();
        btn.onClick.AddListener(PauseMenu);
    }

    void PauseMenu()
    {
        if (PauseOpen)
        {
            Resume();
        }
        else
        {
            OpenPause();
        }
    }
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        PauseOpen = false;
    }
    public void OpenPause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        PauseOpen = true;
    }
}
