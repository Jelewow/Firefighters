using System;
using System.Collections;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private float _waterLevel;
    [SerializeField] private float _waterConsumption;
    [SerializeField] private float _delayBetweenConsumption;

    private float _maxValue;
    private Coroutine _consumpting;
    private WaitForSeconds _delay;

    public event Action<float> SetMaxValue;
    public event Action<float> ValueChanged;
    public event Action WaterEnded;
    public event Action WaterFulled;

    private void Start()
    {
        _delay = new WaitForSeconds(_delayBetweenConsumption);
        _maxValue = _waterLevel;
        SetMaxValue?.Invoke(_maxValue);
    }
    
    public void StartConsumpting()
    {
        _consumpting = StartCoroutine(Consumpting());
    }

    public void StopConsumpting()
    {
        if (_consumpting != null)
            StopCoroutine(_consumpting);
    }

    private void ReloadWater()
    {
        StartCoroutine(Reloading());
    }

    private IEnumerator Consumpting()
    {
        while (_waterLevel > 0)
        {
            _waterLevel -= _waterConsumption;
            _waterLevel = Mathf.Clamp(_waterLevel, 0, _maxValue);
            ValueChanged?.Invoke(_waterLevel);
            if (_waterLevel == 0)
            {
                WaterEnded?.Invoke();
                ReloadWater();
            }
            yield return _delay;
        }
    }

    private IEnumerator Reloading()
    {
        while (_waterLevel < _maxValue)
        {
            _waterLevel += _waterConsumption;
            _waterLevel = Mathf.Clamp(_waterLevel, 0, _maxValue);
            ValueChanged?.Invoke(_waterLevel);
            if (_waterLevel == _maxValue)
            {
                WaterFulled?.Invoke();
            }
            yield return _delay;
        }
    }
}