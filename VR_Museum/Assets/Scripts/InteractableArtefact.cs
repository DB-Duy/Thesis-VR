using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableArtefact : MonoBehaviour
{
    [SerializeField]
    private XRGrabInteractable interactable;
    private Vector3 originalPosition,
        originalRotation,
        originalScale;

    [SerializeField]
    private GameObject description;

    private void OnValidate()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        StoreInformation();
        AddListeners();
    }

    private void StoreInformation()
    {
        originalPosition = interactable.transform.position;
        originalRotation = interactable.transform.rotation.eulerAngles;
        originalScale = interactable.transform.localScale;
    }

    public void ResetObjectTransform()
    {
        if (interactable.isSelected)
        {
            return;
        }
        interactable.transform.SetPositionAndRotation(
            originalPosition,
            Quaternion.Euler(originalRotation)
        );
        interactable.transform.localScale = originalScale;
    }

    public void ToggleDescription()
    {
        description.SetActive(!description.activeSelf);
    }

    private void AddListeners() { }
}
