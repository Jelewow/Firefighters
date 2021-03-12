using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] private FireCounter _fireCounter;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _winMusic;
    [SerializeField] private AudioSource _gameMusic;
    
    private void OnEnable()
    {
        _fireCounter.GameEnded += GameEnd;
    }

    private void OnDisable()
    {
        _fireCounter.GameEnded -= GameEnd;
    }

    private void GameEnd()
    {
        _canvasGroup.DOFade(0, 1.5f);
        _playerInputHandler.enabled = false;
        _winSound.Play();
        _winMusic.Play();
        _gameMusic.Stop();
    }
}