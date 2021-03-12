using UnityEngine;
using TMPro;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private FireCounter _fireCounter;

    private int _fireAmount = 0;
    
    private void OnEnable()
    {
        _fireCounter.FireAdded += OnFireAdded;
        _fireCounter.FireRemoved += OnFireRemoved;
    }

    private void OnDisable()
    {
        _fireCounter.FireAdded -= OnFireAdded;
        _fireCounter.FireRemoved -= OnFireRemoved;
    }

    private void Start()
    {
        _text.text = _fireAmount.ToString();
    }

    private void OnFireAdded()
    {
        _fireAmount++;
        _text.text = _fireAmount.ToString();
    }

    private void OnFireRemoved()
    {
        _fireAmount--;
        _text.text = _fireAmount.ToString();
    }
}
