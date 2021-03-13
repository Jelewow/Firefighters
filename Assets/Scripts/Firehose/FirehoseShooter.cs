using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(WaterLevel))]
public class FirehoseShooter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _waterParticle;
    [SerializeField] private AudioSource _audioSource;

    private WaterLevel _waterLevel;
    private Coroutine _volumeUp;
    private Coroutine _volumeDown;

    private void Awake()
    {
        _audioSource.volume = 0.3f;
        _waterLevel = GetComponent<WaterLevel>();
    }

    public void Shoot()
    {
        TryStartVFX();
        var emission = _waterParticle.emission;
        emission.enabled = true;

        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
            _volumeUp = StartCoroutine(AddVolume());
            if(_volumeDown != null)
                StopCoroutine(_volumeDown);
        }

        _waterLevel.StartConsumpting();
    }

    public void StopShoot()
    {
        var emission = _waterParticle.emission;
        emission.enabled = false;

        _audioSource.Stop();
        if(_volumeUp != null)
            StopCoroutine(_volumeUp);
        _volumeDown = StartCoroutine(ReduceVolume());

        _waterLevel.StopConsumpting();
    }

    private void TryStartVFX()
    {
        if (_waterParticle.isPlaying == false)
            _waterParticle.Play();
    }

    private IEnumerator AddVolume()
    {
        while (_audioSource.volume != 1)
        {
            _audioSource.volume += 0.001f;
            yield return null;
        }
    }

    private IEnumerator ReduceVolume()
    {
        while (_audioSource.volume >= 0.3f)
        {
            _audioSource.volume -= 0.01f;
            yield return null;
        }
    }
}