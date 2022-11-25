using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deaths : MonoBehaviour
{
    public Controlpoint controlpoint;

    public GameObject avoboil;
    public GameObject avofry;
    public GameObject avocut;

    public GameObject carrotboil;
    public GameObject carrotfry;
    public GameObject carrotcut;

    public GameObject onionboil;
    public GameObject onionfry;
    public GameObject onioncut;

    public GameObject eggboil;
    public GameObject eggfry;
    public GameObject eggcut;

    public GameObject tomatoboil;
    public GameObject tomatofry;
    public GameObject tomatocut;

    void Start()
    {
        avoboil.SetActive(false);
        avofry.SetActive(false);
        avocut.SetActive(false);

        carrotboil.SetActive(false);
        carrotfry.SetActive(false);
        carrotcut.SetActive(false);

        onionboil.SetActive(false);
        onionfry.SetActive(false);
        onioncut.SetActive(false);

        eggboil.SetActive(false);
        eggfry.SetActive(false);
        eggcut.SetActive(false);

        tomatoboil.SetActive(false);
        tomatofry.SetActive(false);
        tomatocut.SetActive(false);

    }
    void Update()
    {
        if (controlpoint.tomato == true)
        {
            Debug.Log("tomato");
        }else if(controlpoint.onion == true)
        {
            Debug.Log("onion");
        }
        else if (controlpoint.egg == true)
        {
            Debug.Log("egg");
        }
        else if (controlpoint.avo == true)
        {
            Debug.Log("avo");
        }
        else if (controlpoint.carrot == true)
        {
            Debug.Log("carrot");
        }
    }
}
