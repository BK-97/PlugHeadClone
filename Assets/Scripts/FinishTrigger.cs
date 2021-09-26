using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerBrain>())
        {
            GameManager.Instance.CompeleteStage(true);
        }
    }
}
