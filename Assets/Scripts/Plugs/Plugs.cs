using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugs : MonoBehaviour
{
    Animator animator;
    public GameObject Plug;
    public bool Up;
    bool plugged;
    private void Start()
    {
        animator=GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBrain>())
        {
            if (!plugged)
            {
                plugged = true;
                other.gameObject.GetComponent<PlayerBrain>().Plugged(Plug,Up);
                if (!Up)
                    animator.SetTrigger("Plugged");
                else
                    animator.SetTrigger("PluggedUp");
            }
        }
    }
    public void AnimationEnd()
    {
        EventManager.OnUnplugCharacter.Invoke();
    }
}
