using System;
using UnityEngine;

[RequireComponent(typeof(WaterLevel))]
public class FirehoseShooter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _waterParticle;

    private WaterLevel _waterLevel;

    public ParticleSystem WaterParticle => _waterParticle;

    private void Awake()
    {
        _waterLevel = GetComponent<WaterLevel>();
    }

    public void Shoot()
    {
        TryStartVFX();
        var emission = _waterParticle.emission;
        emission.enabled = true;
        
        _waterLevel.StartConsumpting();
    }

    public void StopShoot()
    {
        var emission = _waterParticle.emission;
        emission.enabled = false;
        
        _waterLevel.StopConsumpting();
    }

    private void TryStartVFX()
    {
        if (_waterParticle.isPlaying == false)
            _waterParticle.Play();
    }
}