using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CameraRotation), typeof(WaterShooter))]
public class PlayerInputHandler : MonoBehaviour
{
    private CameraRotation _cameraRotation;
    private WaterShooter _waterShooter;
    private PlayerInput _input;
    
    private void Awake()
    {
        _cameraRotation = GetComponent<CameraRotation>();
        _waterShooter = GetComponent<WaterShooter>();
        
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

    private void Update()
    {
        var rotate = _input.Main.Rotate.ReadValue<Vector2>();
        _cameraRotation.Rotate(rotate);
    }

    private void StartShooting(InputAction.CallbackContext context)
    {
        _waterShooter.Shoot();
    }

    private void EndShooting(InputAction.CallbackContext context)
    {
        _waterShooter.StopShoot();
    }
}