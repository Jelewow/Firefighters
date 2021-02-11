using UnityEngine;

public class WaterShooter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _mainParticle;
    
    public void Shoot()
    {
        TryStartVFX();
        
        var emission = _mainParticle.emission;
        emission.enabled = true;
    }

    public void StopShoot()
    {
        var emission = _mainParticle.emission;
        emission.enabled = false;
    }

    private void TryStartVFX()
    {
        if (_mainParticle.isPlaying == false)
            _mainParticle.Play();
    }
}