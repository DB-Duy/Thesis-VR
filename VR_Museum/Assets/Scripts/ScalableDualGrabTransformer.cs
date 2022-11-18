using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class ScalableDualGrabTransformer : XRSingleGrabFreeTransformer
{
    [SerializeField, HideInInspector]
    private InteractableArtefact _artefact;

    [SerializeField]
    private XRBaseInteractable _interactable;

    [SerializeField]
    private float _maxScaleMultiplierThreshold = 2,
        _minScaleMultiplierThreshold = 0.5f;
    private bool _isScaling = false;
    private float _initialDistance = 0;

    [SerializeField]
    private InputActionProperty _activateInputLeftHand,
        _activateInputRightHand,
        _leftHandPosition,
        _rightHandPosition;

    private void OnValidate()
    {
        _interactable = GetComponent<XRBaseInteractable>();
        _artefact = GetComponent<InteractableArtefact>();
    }

    public override void Process(
        XRGrabInteractable grabInteractable,
        XRInteractionUpdateOrder.UpdatePhase updatePhase,
        ref Pose targetPose,
        ref Vector3 localScale
    )
    {
        base.Process(grabInteractable, updatePhase, ref targetPose, ref localScale);

        TwoHandedScaleObject(ref localScale);
    }

    private void TwoHandedScaleObject(ref Vector3 localScale)
    {
        if (
            _interactable.interactorsHovering.Count < 2
            || _interactable.interactorsSelecting.Count < 1
            || !OtherHandActivating()
        )
        {
            if (_isScaling)
            {
                _isScaling = false;
                _initialDistance = 0;
            }
            return;
        }

        Vector3 leftHandPosition = _leftHandPosition.action.ReadValue<Vector3>();
        Vector3 rightHandPosition = _rightHandPosition.action.ReadValue<Vector3>();

        if (_initialDistance == 0)
        {
            _initialDistance = Vector3.Distance(leftHandPosition, rightHandPosition);
            return;
        }

        _isScaling = true;
        float scaleMultiplier =
            Vector3.Distance(leftHandPosition, rightHandPosition) / _initialDistance;

        if (
            (localScale.x * scaleMultiplier) / _artefact.OriginalTransform.originalScale.x
            > _maxScaleMultiplierThreshold
        )
        {
            scaleMultiplier = _maxScaleMultiplierThreshold;
        }
        else if (
            (localScale.x * scaleMultiplier) / _artefact.OriginalTransform.originalScale.x
            < _minScaleMultiplierThreshold
        )
        {
            scaleMultiplier = _minScaleMultiplierThreshold;
        }
        localScale = _artefact.OriginalTransform.originalScale * scaleMultiplier;
    }

    private bool OtherHandActivating()
    {
        XRBaseInteractor otherInteractor =
            (IXRInteractor)_interactable.interactorsSelecting[0]
            == (IXRInteractor)_interactable.interactorsHovering[0]
                ? (XRBaseInteractor)_interactable.interactorsHovering[1]
                : (XRBaseInteractor)_interactable.interactorsHovering[0];
        if (otherInteractor.CompareTag("LeftHand"))
        {
            return _activateInputLeftHand.action.IsPressed();
        }
        else
        {
            return _activateInputRightHand.action.IsPressed();
        }
    }
}
