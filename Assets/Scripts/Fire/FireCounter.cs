using System;
using System.Collections;
using UnityEngine;

public class FireCounter : MonoBehaviour
{
    private int _fireAmount;
    private FireExtinguisher[] _fires;

    public event Action FireAdded;
    public event Action FireRemoved;
    public event Action GameEnded;
    
    private void Awake()
    {
        _fires = GetComponentsInChildren<FireExtinguisher>();
    }

    private void OnEnable()
    {
        foreach (var fire in _fires)
        {
            fire.Spawned += OnFireSpawned;
            fire.Extinguished += OnFireExtinguished;
        }
    }

    private void OnDisable()
    {
        foreach (var fire in _fires)
        {
            fire.Spawned -= OnFireSpawned;
            fire.Extinguished -= OnFireExtinguished;
        }
    }

    private void OnFireSpawned()
    {
        _fireAmount++;
        FireAdded?.Invoke();
    }

    private void OnFireExtinguished()
    {
        _fireAmount--;
        FireRemoved?.Invoke();

        if (_fireAmount == 0)
            StartCoroutine(WaitDelay());
    }
    
    private IEnumerator WaitDelay()
    {
        yield return new WaitForSeconds(1f);
        GameEnded?.Invoke();
    }
}