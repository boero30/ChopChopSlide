using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum Chefstates { Cutting, Inspecting }

public class ChefAI : MonoBehaviour
{
    public Controlpoint controlpoint;

    private Animator animator;

    [SerializeField] private float startInspectionTime = 5f;

    [SerializeField] private AudioSource _cutfast;

    private float currentInspectionTime;

    private Controlpoint veggie;

    private Chefstates currentState = Chefstates.Cutting;

    public GameObject greenlight;

    public GameObject redlight;

    public GameObject yellowlight;

    void Start()
    {
        veggie = FindObjectOfType<Controlpoint>();

        animator = GetComponent<Animator>();

        currentInspectionTime = startInspectionTime;        

        greenlight.SetActive(true);

        redlight.SetActive(false);

        yellowlight.SetActive(false);
    }
    void Update()
    {
        if (veggie != null)
        {
            StateMachine();
        }
    }
    private void StateMachine()
    {
        switch (currentState)
        {
            case Chefstates.Cutting:
                Cut();
                break;
            case Chefstates.Inspecting:
                Inspect();
                break;
            default:
                break;
        }
    }

    private void Cut()
    {
        if (!_cutfast.isPlaying)
        {
            animator.SetTrigger("Look");

            currentState = Chefstates.Inspecting;

            redlight.SetActive(false);
        }
    }

    private void Inspect()
    {
        if(currentInspectionTime > 0)
        {
            currentInspectionTime -= Time.deltaTime;

            if (veggie.IsMoving())
            {
                if (controlpoint.tomato == true)
                {
                    SceneManager.LoadScene(26);
                }
                else if (controlpoint.onion == true)
                {
                    SceneManager.LoadScene(23);
                }
                else if (controlpoint.egg == true)
                {
                    SceneManager.LoadScene(20);
                }
                else if (controlpoint.avo == true)
                {
                    SceneManager.LoadScene(13);
                }
                else if (controlpoint.carrot == true)
                {
                    SceneManager.LoadScene(16);
                }
            }

            greenlight.SetActive(false);
            redlight.SetActive(true);
        }
        else
        {
            currentInspectionTime = startInspectionTime;

            _cutfast.Play();

            StopAllCoroutines();
            greenlight.SetActive(true);

            redlight.SetActive(false);
            currentState = Chefstates.Cutting;
        }
    }

}
