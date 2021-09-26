using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamFollower : MonoBehaviour
{
    public Transform Target;
    public CinemachineVirtualCamera CMV1;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,Target.position.z);
    }
}
