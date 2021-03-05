using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguishing : MonoBehaviour
{
    private ParticleSystem _fire;

    private List<ParticleSystem.Particle> _enter = new List<ParticleSystem.Particle>();
    
    private void Awake()
    {
        _fire = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        print("hello");
        var enter = _fire.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, _enter);
        print(enter);
    }
}