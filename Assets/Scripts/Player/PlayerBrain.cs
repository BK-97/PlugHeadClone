using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBrain : MonoBehaviour
{
    public float Speed;
    public bool MoveForward;
    public bool MoveBack;
    private int health=3;
    bool isPlugged;
    bool firstTouch;
    bool FinalSession;
    bool isDead;
    public Animator animator;
    Transform puppetMasterParent;
    private void OnEnable()
    {
        EventManager.OnUnplugCharacter.AddListener(UnPlugged);
    }
    private void OnDisable()
    {
        EventManager.OnUnplugCharacter.RemoveListener(UnPlugged);

    }
    private void Start()
    {
        puppetMasterParent = transform.parent;
    }
    // Update is called once per frame
    void Update()
    {
        if (!FinalSession&& !isDead)
        {
            if (MoveForward && !MoveBack)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            }
            if (MoveBack)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * -Speed);
            }
            if (!isPlugged)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!firstTouch)
                    {
                        firstTouch = true;
                        animator.SetBool("Run", true);
                        MoveForward = true;
                    }
                    if (!MoveForward)
                    {
                        MoveForward = true;
                        animator.SetBool("Run", true);
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    if (firstTouch)
                    {
                        MoveForward = false;
                        animator.SetBool("Run", false);
                    }
                }
            }
        }
        
    }
    public void Hit()
    {
        health--;
        if(health==0)
        {
            isDead = true;
            animator.SetBool("Run", false);
            animator.SetTrigger("Dead");
            transform.DOMove(new Vector3(transform.position.x,transform.position.y-0.25f,transform.position.z-1f),1f);
            StartCoroutine(WaitDeadCO());
        }
        else
            StartCoroutine(GoBackCO());
        
    }
    IEnumerator WaitDeadCO()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.CompeleteStage(false);

    }
    IEnumerator GoBackCO()
    {
        MoveBack = true;
        yield return new WaitForSeconds(0.5f);
        MoveBack = false;
    }
    bool UpPlug;
    public void Plugged(GameObject Plug,bool Up)
    {
        MoveForward = false;
        MoveBack = false;
        isPlugged = true;
        transform.parent = Plug.transform;
        UpPlug = Up;
    }
    public void UnPlugged()
    {
        StartCoroutine(WaitUnPlug());
        puppetMasterParent.GetComponentInChildren<RootMotion.Dynamics.PuppetMaster>().pinWeight = 0.6f;
        transform.parent = puppetMasterParent;
        transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    IEnumerator WaitUnPlug()
    {
        if (UpPlug)
        {
            transform.DOMove(new Vector3(transform.position.x,transform.position.y+0.25f,transform.position.z+2f),0.5f);
        }
        MoveForward = true;
        Speed = 2f;
        yield return new WaitForSeconds(1f);
        puppetMasterParent.GetComponentInChildren<RootMotion.Dynamics.PuppetMaster>().pinWeight = 0.78f;
        Speed = 8f;
        MoveForward = false;
        animator.SetBool("Run", false);
        isPlugged = false;

    }
    public void FinishTrigger(GameObject FinishPlug)
    {
        FinalSession = true;
        GetComponent<Rigidbody>().useGravity = false;
        animator.SetBool("Run", true);

        transform.DOMove(new Vector3(FinishPlug.transform.position.x,transform.position.y,FinishPlug.transform.position.z),1f);
    }
    public void FinishPlug(GameObject FinalPlug)
    {
        DOTween.KillAll();
        MoveForward = false;
        MoveBack = false;
        isPlugged = true;
        transform.parent = FinalPlug.transform;
        StartCoroutine(FinishCO());
        
    }
    IEnumerator FinishCO()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.CompeleteStage(true);
    }
}
