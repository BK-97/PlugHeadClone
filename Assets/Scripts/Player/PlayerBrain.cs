using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    public float Speed;
    public bool MoveForward;
    public bool MoveBack;
    bool isPlugged;
    bool firstTouch;
    public Animator animator;

    private void OnEnable()
    {
        EventManager.OnUnplugCharacter.AddListener(UnPlugged);
    }
    private void OnDisable()
    {
        EventManager.OnUnplugCharacter.RemoveListener(UnPlugged);

    }
    // Update is called once per frame
    void Update()
    {
        if (!isPlugged)
        {
            if (MoveForward && !MoveBack)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            }
            if (MoveBack)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * -Speed);
            }

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
        isPlugged = true;
        transform.parent = Plug.transform;
    }
    public void UnPlugged()
    {
        transform.parent = null;
        animator.SetBool("Run", false);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x,0,transform.position.z+.5f);
        isPlugged = false;
    }
}
