using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private Transform _currentPanel;
    [SerializeField] private Transform _placeForPanel;
    [SerializeField] private float _moveDuration;
    [SerializeField] private FireCounter _fireCounter;
    [SerializeField] private Button _button;
    
    private Vector3 _startPanelPosition;
    private Vector3 _newPanelPosition;

    public event Action PopUped;

    private void OnEnable()
    {
        _fireCounter.GameEnded += GameEnd;
    }

    private void OnDisable()
    {
        _fireCounter.GameEnded -= GameEnd;
    }

    private void Start()
    {
        _startPanelPosition = _currentPanel.transform.position;
        _newPanelPosition = _placeForPanel.transform.position;
    }
    
    private void GameEnd()
    {
        var nextPanelPosition = GetNextPanelPosition();
        SwitchTopOrBottomPanelPosition(nextPanelPosition);
        _button.gameObject.SetActive(true);
    }
    
    private void SwitchTopOrBottomPanelPosition(Vector3 newPosition)
    {
        _currentPanel.DOMove(newPosition, _moveDuration);
        StartCoroutine(WaitPopUping());
    }

    private IEnumerator WaitPopUping()
    {
        yield return new WaitForSeconds(_moveDuration - 0.2f);
        PopUped?.Invoke();
    }
    
    private Vector3 GetNextPanelPosition()
    {
        if (_currentPanel.position == _newPanelPosition)
            return _startPanelPosition;
        else
            return _newPanelPosition;
    }
}
