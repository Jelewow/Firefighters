using System;
using UnityEngine;

[RequireComponent(typeof(WaterLevel))]
public class WaterShooter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _mainParticle;

    private WaterLevel _waterLevel;

    private void Awake()
    {
        _waterLevel = GetComponent<WaterLevel>();
    }

    public void Shoot()
    {
        TryStartVFX();
        var emission = _mainParticle.emission;
        emission.enabled = true;
        
        _waterLevel.StartConsumpting();
    }

    public void StopShoot()
    {
        var emission = _mainParticle.emission;
        emission.enabled = false;
        
        _waterLevel.StopConsumpting();
    }

    private void TryStartVFX()
    {
        if (_mainParticle.isPlaying == false)
            _mainParticle.Play();
    }
}