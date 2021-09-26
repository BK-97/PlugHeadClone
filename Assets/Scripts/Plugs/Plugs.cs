using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugs : MonoBehaviour
{
    Animator animator;
    public GameObject Plug;
    private void Start()
    {
        animator=GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBrain>().MoveForward)
        {
            Debug.Log("trigger");
            other.gameObject.GetComponent<PlayerBrain>().Plugged(Plug);
            animator.SetTrigger("Plugged");
        }
    }
}