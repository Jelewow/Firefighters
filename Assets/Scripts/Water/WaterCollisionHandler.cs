using UnityEngine;

public class WaterCollisionHandler : MonoBehaviour
{
    [SerializeField] private FireExtinguisher _fireExtinguisher;
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.TryGetComponent(out ParticleSystem particleSystem))
        {
            _fireExtinguisher.Extingushing();
        }
    }
}