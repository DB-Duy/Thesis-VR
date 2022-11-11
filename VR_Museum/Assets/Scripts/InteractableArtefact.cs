using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableArtefact : MonoBehaviour
{
    [SerializeField]
    private XRGrabInteractable interactable;

    private void OnValidate()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        interactable.selectEntered.AddListener(OnPickUp);
        interactable.selectExited.AddListener(OnDrop);
    }

    public int handsActive = 0;

    public void OnPickUp(SelectEnterEventArgs args)
    {
        handsActive++;
        print(handsActive);
    }

    public void OnDrop(SelectExitEventArgs args)
    {
        handsActive--;
    }

    private void Update()
    {
        if (handsActive == 2)
        {
            ScaleObject();
        }
    }

    private void ScaleObject()
    {
        transform.localScale *= Vector3.Distance(
            VRPlayer.player.handLeft.transform.position,
            VRPlayer.player.handRight.transform.position
        );
    }
}
