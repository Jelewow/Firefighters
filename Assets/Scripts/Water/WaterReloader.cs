using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaterLevel))]
public class WaterReloader : MonoBehaviour
{
    private WaterLevel _waterLevel;

    private void Awake()
    {
        _waterLevel = GetComponent<WaterLevel>();
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
        
    }
}
