using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField] private float _extingushingForce;

    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private ParticleSystem _smoke;
    [SerializeField] private ParticleSystem _smoke2;

    private Collider _collider;

    public event Action<float> SetMaxValue;
    public event Action<float> ValueChanged;
    public event Action Spawned;
    public event Action Extinguished;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        SetMaxValue?.Invoke(_fire.velocityOverLifetime.speedModifierMultiplier);
        ValueChanged?.Invoke(_fire.velocityOverLifetime.speedModifierMultiplier);
        Spawned?.Invoke();
    }

    public void Extingushing()
    {
        var velocityOverLifetimeModule = _fire.velocityOverLifetime;
        velocityOverLifetimeModule.speedModifierMultiplier -= 0.01f;
        ValueChanged?.Invoke(_fire.velocityOverLifetime.speedModifierMultiplier);

        _smoke.Play();
        _smoke2.Play();
        var emissionModule = _smoke.emission;
        emissionModule.rateOverTimeMultiplier += 5;
        
        var emissionModule2 = _smoke2.emission;
        emissionModule2.rateOverTimeMultiplier += 5;

        if (_fire.velocityOverLifetime.speedModifierMultiplier <= 0)
        {
            _collider.enabled = false;
            Extinguished?.Invoke();
            _fire.Stop();
            StartCoroutine(Smoking());
        }
    }

    private IEnumerator Smoking()
    {
        _smoke.Play();
        _smoke2.Play();
        while (_smoke.emission.rateOverTimeMultiplier > 0)
        {
            var emissionModule = _smoke.emission;
            emissionModule.rateOverTimeMultiplier -= 20;
        
            var emissionModule2 = _smoke2.emission;
            emissionModule2.rateOverTimeMultiplier -= 20;
            yield return null;
        }

        _smoke.Stop();
    }
}