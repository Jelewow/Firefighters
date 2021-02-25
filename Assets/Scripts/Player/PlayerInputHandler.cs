using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CameraRotation), typeof(FirehoseShooter))]
public class PlayerInputHandler : MonoBehaviour
{
    private CameraRotation _cameraRotation;
    private FirehoseShooter _firehoseShooter;
    private PlayerInput _input;
    
    private void Awake()
    {
        _cameraRotation = GetComponent<CameraRotation>();
        _firehoseShooter = GetComponent<FirehoseShooter>();
        
        _input = new PlayerInput();
        _input.Enable();
    }

    private void OnEnable()
    {
        _input.Main.Shoot.started += StartShooting;
        _input.Main.Shoot.canceled += EndShooting;
    }

    private void OnDisable()
    {
        _input.Main.Shoot.started -= StartShooting;
        _input.Main.Shoot.canceled -= EndShooting;
    }

    private void FixedUpdate()
    {
        var scaledVector = _input.Main.Rotate.ReadValue<Vector2>() * Time.fixedDeltaTime;
        _cameraRotation.Rotate(scaledVector);
    }

    private void StartShooting(InputAction.CallbackContext context)
    {
        if(_firehoseShooter.enabled == true)
            _firehoseShooter.Shoot();
    }

    private void EndShooting(InputAction.CallbackContext context)
    {
        if(_firehoseShooter.enabled == true)
            _firehoseShooter.StopShoot();
    }
}