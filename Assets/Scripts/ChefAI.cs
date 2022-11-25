using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Chefstates { Cutting, Inspecting }

public class ChefAI : MonoBehaviour
{
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

    public IEnumerator TrafficLights()
    {
        greenlight.SetActive(false);
        yellowlight.SetActive(true);
        yield return new WaitForSeconds(1);
        yellowlight.SetActive(false);
        redlight.SetActive(true);
        yield return null;
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
                Debug.Log("loseeee");
            }

            //StartCoroutine(TrafficLights());
            greenlight.SetActive(false);
            redlight.SetActive(true);
            //StopAllCoroutines();
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
