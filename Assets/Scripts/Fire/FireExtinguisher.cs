using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField] private float _extingushingForce;

    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private ParticleSystem _smoke;
    [SerializeField] private ParticleSystem _smoke2;
    
    [SerializeField] private CanvasGroup _canvasGroup;

    private Collider _collider;

    public event Action<float> SetMaxValue;
    public event Action<float> ValueChanged;
    public event Action Spawned;
    public event Action Extinguished;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _audioSource.volume = 0.9f;
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
        velocityOverLifetimeModule.speedModifierMultiplier -= _extingushingForce;
        ValueChanged?.Invoke(_fire.velocityOverLifetime.speedModifierMultiplier);

        _smoke.Play();
        _smoke2.Play();

        if(_audioSource.isPlaying == false)
            _audioSource.Play();
            
        var emissionModule = _smoke.emission;
        emissionModule.rateOverTimeMultiplier += 2;
        
        var emissionModule2 = _smoke2.emission;
        emissionModule2.rateOverTimeMultiplier += 2;

        if (_fire.velocityOverLifetime.speedModifierMultiplier <= 0)
        {
            _collider.enabled = false;
            Extinguished?.Invoke();
            _fire.Stop();
            StartCoroutine(Smoking());
            _canvasGroup.DOFade(0, 1.5f);
        }
    }

    private IEnumerator Smoking()
    {
        _smoke.Play();
        _smoke2.Play();
        while (_smoke.emission.rateOverTimeMultiplier > 0)
        {
            var emissionModule = _smoke.emission;
            emissionModule.rateOverTimeMultiplier -= 40;

            _audioSource.volume -= 0.15f;
            
            var emissionModule2 = _smoke2.emission;
            emissionModule2.rateOverTimeMultiplier -= 40;
            yield return null;
        }
        _audioSource.Stop();
        _audioSource.volume = 0.9f;
        _smoke.Stop();
    }
}