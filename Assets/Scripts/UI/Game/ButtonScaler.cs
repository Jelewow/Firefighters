using UnityEngine;
using DG.Tweening;

public class ButtonScaler : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private float _to;
    [SerializeField] private float _durarion;

    private void OnEnable()
    {
        _button.transform.DOScale(_to, _durarion).SetLoops(-1, LoopType.Yoyo);
    }
}