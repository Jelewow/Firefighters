using UnityEngine;

public class BarRotation : MonoBehaviour
{
    [SerializeField] private GameObject _bar;

    private void Start()
    {
        var target = Camera.main.transform.localPosition;
        _bar.transform.LookAt(target);
    }
}