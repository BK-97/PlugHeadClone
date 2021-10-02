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
        if (other.gameObject.GetComponent<PlayerBrain>())
        {
            
            other.gameObject.GetComponent<PlayerBrain>().Plugged(Plug);
            animator.SetTrigger("Plugged");

        }
    }
    public void AnimationEnd()
    {
        EventManager.OnUnplugCharacter.Invoke();
    }
}
