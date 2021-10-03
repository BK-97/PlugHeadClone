using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamFollower : MonoBehaviour
{
    public Transform Target;
    public CinemachineVirtualCamera CMV1;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Target.position.y,Target.position.z);
    }
}
