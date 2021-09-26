using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    public float Speed;
    public bool MoveForward;
    bool MoveBack;
    bool isPlugged;
    bool firstTouch;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(1f);
        MoveBack = false;
    }
    public void Plugged(GameObject Plug)
    {
        isPlugged = true;
        transform.parent = Plug.transform;
    }
}
