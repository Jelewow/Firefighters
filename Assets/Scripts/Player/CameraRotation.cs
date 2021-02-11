using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private float _xBorder = 25;
    private float _yBorder = 40;
    
    public void Rotate(Vector2 rotation)
    {
        var scaledRotateSpeed = _rotateSpeed * Time.deltaTime;
        var y = Mathf.Clamp(rotation.x, -20, 20);
        var x = Mathf.Clamp(rotation.y, -10f, 10f);
        var direction = new Vector3(x, y);
        transform.rotation = Quaternion.Euler(direction);
        //print(transform.localEulerAngles);
    }
}