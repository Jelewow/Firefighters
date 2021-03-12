using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private PopUp _popUp;
    
    private Slider _slider; // 0.568
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _popUp.PopUped += ThiefProgress;
    }

    private void OnDisable()
    {
        _popUp.PopUped -= ThiefProgress;
    }

    private void ThiefProgress()
    {
        _slider.DOValue(0.568f, 1.2f);
    }
}