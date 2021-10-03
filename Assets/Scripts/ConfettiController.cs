using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiController : MonoBehaviour
{
    public List<ParticleSystem> Particles;
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Particles.Add(transform.GetChild(i).GetComponent<ParticleSystem>());
        }
    }
    public void ConfettiPlay()
    {
        for (int i = 0; i < Particles.Count; i++)
        {
            Particles[i].Play();
        }
    }
}
