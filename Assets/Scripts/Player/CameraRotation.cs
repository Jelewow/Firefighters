using System;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private Vector3 _previousRotation;
    private Quaternion _center;

    private void Start()
    {
        _center = transform.rotation;
    }

    public void Rotate(Vector2 scaledVector)
    {
        var scaledRotationSpeed = scaledVector * _rotateSpeed;
        var x = CalculateAngle(scaledRotationSpeed.x, Vector2.up);
        var y = CalculateAngle(scaledRotationSpeed.y, Vector2.right);
        var clampAngles = ClampAngles(x, y).eulerAngles;
        clampAngles.z = 0;
        transform.localEulerAngles = clampAngles;
    }

    private Quaternion ClampAngles(Quaternion x, Quaternion y)
    {
        var resultantAngle = transform.localRotation * x * y;
        if (Quaternion.Angle(_center, resultantAngle) <= 40)
        {
            return resultantAngle;
        }

        return transform.localRotation;
    }

    private Quaternion CalculateAngle(float axis, Vector2 direction)
    {
        return Quaternion.AngleAxis(axis, direction);
    }
}