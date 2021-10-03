using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugs : MonoBehaviour
{
    Animator animator;
    public GameObject Plug;
    public bool UpPlug;
    public bool FinishPlug;
    bool plugged;
    private void Start()
    {
        animator=GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBrain>())
        {
            if (!plugged&&!FinishPlug)
            {
                plugged = true;
                other.gameObject.GetComponent<PlayerBrain>().Plugged(Plug,UpPlug);
                if (!UpPlug)
                    animator.SetTrigger("Plugged");
                else
                    animator.SetTrigger("PluggedUp");
            }
            if (!plugged && FinishPlug)
            {
                plugged = true;
                other.gameObject.GetComponent<PlayerBrain>().FinishPlug(Plug);
                animator.SetTrigger("FinishPlug");

            }
        }
    }
    public void AnimationEnd()
    {
        EventManager.OnUnplugCharacter.Invoke();
    }
}
