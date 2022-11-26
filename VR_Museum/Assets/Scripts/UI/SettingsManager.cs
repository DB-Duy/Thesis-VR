using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private ActionBasedContinuousMoveProvider _moveProvider;

    [SerializeField]
    private ActionBasedContinuousTurnProvider _turnProvider;

    public void SetMoveSpeed(float speed)
    {
        _moveProvider.moveSpeed = speed;
    }

    public void SetTurnSpeed(float speed)
    {
        _turnProvider.turnSpeed = speed;
    }
}
