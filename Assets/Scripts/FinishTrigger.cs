using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FinishPlug;
    private ConfettiController confettiController;
    private void Start()
    {
        confettiController = FindObjectOfType<ConfettiController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerBrain>())
        {
            other.GetComponent<PlayerBrain>().FinishTrigger(FinishPlug);
            confettiController.ConfettiPlay();
        }
    }
}
