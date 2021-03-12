using UnityEngine;

public class ProgressSound : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private FireExtinguisher _fireExtinguisher;
    
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _fireExtinguisher = GetComponent<FireExtinguisher>();
    }

    private void OnEnable()
    {
        _fireExtinguisher.Extinguished += PlaySound;
    }

    private void OnDisable()
    {
        _fireExtinguisher.Extinguished -= PlaySound;
    }

    private void PlaySound()
    {
        _audioSource.Play();   
        _particleSystem.Play();
    }
}