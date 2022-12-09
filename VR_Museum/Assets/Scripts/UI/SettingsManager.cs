using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private ActionBasedContinuousMoveProvider _moveProvider;

    [SerializeField]
    private ActionBasedContinuousTurnProvider _turnProvider;

    [SerializeField]
    private TeleportationProvider _teleport;

    [SerializeField]
    private GameObject _xrOrigin;

    [SerializeField]
    private Slider _turnSlider,
        _speedSlider;

    private Vector3 _originalPlayerPosition,
        _originalPlayerRotation;
    private TeleportRequest _teleportResetPosition;

    private void Start()
    {
        _originalPlayerPosition = _xrOrigin.transform.position;
        _originalPlayerRotation = _xrOrigin.transform.eulerAngles;
        _teleportResetPosition = new TeleportRequest()
        {
            destinationPosition = _originalPlayerPosition,
            destinationRotation = Quaternion.Euler(_originalPlayerRotation),
            requestTime = 0,
            matchOrientation = MatchOrientation.TargetUpAndForward
        };
    }

    public void ResetPlayerTransform()
    {
        _teleport.QueueTeleportRequest(_teleportResetPosition);
    }

    public void SetMoveSpeed(float speed)
    {
        _moveProvider.moveSpeed = speed;
    }

    public void ResetMoveSpeed()
    {
        _moveProvider.moveSpeed = 1;
        _speedSlider.value = 1;
        ;
    }

    public void SetTurnSpeed(float speed)
    {
        _turnProvider.turnSpeed = speed;
    }

    public void ResetTurnSpeed()
    {
        _turnProvider.turnSpeed = 60;
        _turnSlider.value = 60;
    }
}
