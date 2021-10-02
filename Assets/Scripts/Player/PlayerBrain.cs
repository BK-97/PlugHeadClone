using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBrain : MonoBehaviour
{
    public float Speed;
    public bool MoveForward;
    public bool MoveBack;
    bool isPlugged;
    bool firstTouch;
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
    public void Hit()
    {
        StartCoroutine(GoBackCO());
        
    }
    IEnumerator GoBackCO()
    {
        MoveBack = true;
        yield return new WaitForSeconds(0.5f);
        MoveBack = false;
    }
    public void Plugged(GameObject Plug)
    {
        MoveForward = false;
        MoveBack = false;
        isPlugged = true;
        transform.parent = Plug.transform;
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
        MoveForward = true;
        Speed = 2f;
        yield return new WaitForSeconds(1f);
        puppetMasterParent.GetComponentInChildren<RootMotion.Dynamics.PuppetMaster>().pinWeight = 0.78f;
        Speed = 10f;
        MoveForward = false;
        animator.SetBool("Run", false);
        isPlugged = false;

    }
}
