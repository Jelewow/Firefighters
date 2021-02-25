using System;
using UnityEngine;

[RequireComponent(typeof(FirehoseShooter))]
public class FirehoseState : MonoBehaviour
{
    [SerializeField] private WaterLevel _waterLevel;
    
    private FirehoseShooter _shooter;

    private void Awake()
    {
        _shooter = GetComponent<FirehoseShooter>();
    }

    private void OnEnable()
    {
        _waterLevel.WaterEnded += OnWaterEnded;
        _waterLevel.WaterFulled += OnWaterFulled;
    }

    private void OnDisable()
    {
        _waterLevel.WaterEnded -= OnWaterEnded;
        _waterLevel.WaterFulled -= OnWaterFulled;
    }

    private void OnWaterEnded()
    {
        BlockFirehose();
    }

    private void OnWaterFulled()
    {
        UnBlockFirehose();
    }
    
    private void BlockFirehose()
    {
        _shooter.StopShoot();
        _shooter.enabled = false;
    }

    private void UnBlockFirehose()
    {
        _shooter.enabled = true;
    }
}