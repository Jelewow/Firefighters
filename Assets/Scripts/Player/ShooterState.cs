using System;
using UnityEngine;

[RequireComponent(typeof(WaterShooter))]
public class ShooterState : MonoBehaviour
{
    [SerializeField] private WaterLevel _waterLevel;
    
    private WaterShooter _shooter;

    private void Awake()
    {
        _shooter = GetComponent<WaterShooter>();
    }

    private void OnEnable()
    {
        _waterLevel.WaterEnded += OnWaterEnded;
    }

    private void OnDisable()
    {
        _waterLevel.WaterEnded -= OnWaterEnded;
    }

    private void OnWaterEnded()
    {
        _shooter.StopShoot();
        _shooter.enabled = false;
    }
}