using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private FireExtinguisher _fireLevel;

    private float _maxValue;
    
    private void OnEnable()
    {
        _fireLevel.ValueChanged += OnValueChanged;
        _fireLevel.SetMaxValue += SetMaxValue;
    }
    
    private void OnDisable()
    {
        _fireLevel.ValueChanged -= OnValueChanged;
        _fireLevel.SetMaxValue -= SetMaxValue;
    }

    private void OnValueChanged(float value)
    {
        var normalValue = NormalizeValue(value);
        _slider.value = normalValue;
    }

    private float NormalizeValue(float value)
    {
        var normalValue = value / _maxValue;
        return normalValue;
    }
    
    private void SetMaxValue(float maxValue)
    {
        _maxValue = maxValue;
    }
}