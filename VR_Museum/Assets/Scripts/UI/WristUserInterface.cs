using UnityEngine;
using UnityEngine.InputSystem;

public class WristUserInterface : MonoBehaviour
{
    [SerializeField]
    private GameObject _wristInterface,
        _rightHandRayInteractor;

    [SerializeField]
    private InputActionProperty _menuButton;

    private void Start()
    {
        _menuButton.action.performed += ToggleWristInterface;
    }

    private void ToggleWristInterface(InputAction.CallbackContext args)
    {
        _wristInterface.SetActive(!_wristInterface.activeSelf);
        _rightHandRayInteractor.SetActive(_wristInterface.activeInHierarchy);
    }
}
