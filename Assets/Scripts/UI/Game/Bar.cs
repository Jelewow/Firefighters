using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private WaterLevel _waterLevel;

    private int _digitCount;
    
    private void OnEnable()
    {
        _waterLevel.ValueChanged += OnValueChanged;
        _waterLevel.SetMaxValue += SetMaxValue;
    }
    
    private void OnDisable()
    {
        _waterLevel.ValueChanged -= OnValueChanged;
        _waterLevel.SetMaxValue -= SetMaxValue;
    }

    private void OnValueChanged(float value)
    {
        var normalValue = NormalizeValue(value);
        _slider.value = normalValue;
    }

    private float NormalizeValue(float value)
    {
        var normalValue = value / _digitCount;
        return normalValue;
    }
    
    private void SetMaxValue(float maxValue)
    {
        _digitCount = CalculateDigits(maxValue);
    }

    private int CalculateDigits(float value)
    {
        var digitsCount = value.ToString().Length;
        var divider = 1;
        
        for (int i = 1; i < digitsCount; i++)
        {
            divider *= 10;
        }
        return divider;
    }
}