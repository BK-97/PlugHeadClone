using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    public float Speed;
    bool MoveForward;
    bool firstTouch;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveForward)
        {
            transform.Translate(Vector3.forward*Time.deltaTime*Speed);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("touched");
            if (!firstTouch)
            {
                firstTouch = true;
                animator.SetBool("Run",true);
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
