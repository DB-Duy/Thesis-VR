using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty _movement;

    [SerializeField]
    private AudioSource _footStepAudio;

    public float stepRate = 0.5f;

    public float stepCoolDown;

    public AudioClip footStep;

    private bool _isPlayerMoving;

    private void Start()
    {
        _movement.action.started += MovementStart;
        _movement.action.canceled += MovementStop;
    }

    public void MovementStart(InputAction.CallbackContext arg)
    {
        _isPlayerMoving = true;
    }

    public void MovementStop(InputAction.CallbackContext arg)
    {
        _isPlayerMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        stepCoolDown -= Time.deltaTime;
        if (_isPlayerMoving && stepCoolDown < 0f)
        {
            _footStepAudio.pitch = 1f + Random.Range(-0.2f, 0.2f);
            _footStepAudio.PlayOneShot(footStep, 0.9f);
            stepCoolDown = stepRate;
        }
    }
}
