using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayer : MonoBehaviour
{
    public static VRPlayer player;

    public GameObject leftHand,
        rightHand;

    [SerializeField]
    private XRRayInteractor leftHandRay,
        rightHandRay;

    [SerializeField]
    private LocomotionSystem playerLocomotion;

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }
    }

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        leftHandRay.selectEntered.AddListener(DisableMovementOnPickUp);
        leftHandRay.selectExited.AddListener(EnableMovementOnPutDown);
        rightHandRay.selectEntered.AddListener(DisableMovementOnPickUp);
        rightHandRay.selectExited.AddListener(EnableMovementOnPutDown);
    }

    public void DisableMovementOnPickUp(SelectEnterEventArgs args)
    {
        playerLocomotion.enabled = false;
    }

    public void EnableMovementOnPutDown(SelectExitEventArgs args)
    {
        playerLocomotion.enabled = true;
    }
}
