using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public struct OriginalTransform
{
    public Vector3 originalPosition;

    public Vector3 originalScale;

    public Vector3 originalRotation;
}

public class InteractableArtefact : MonoBehaviour
{
    [SerializeField]
    private XRGrabInteractable _interactable;

    public OriginalTransform OriginalTransform { get; private set; }

    private float _initialDistance = 0;

    [SerializeField]
    private bool _isRotating = false;

    [SerializeField]
    private GameObject _description;

    public string DefaultDescription;

    [SerializeField]
    private float _rotateSpeed = 1f;

    [SerializeField]
    private DescriptionCollider[] _descriptionColliders;

    private void OnValidate()
    {
        _interactable = GetComponent<XRGrabInteractable>();
        _descriptionColliders = GetComponentsInChildren<DescriptionCollider>();
    }

    private void Start()
    {
        StoreInformation();
    }

    private void Update()
    {
        RotateOnUpdate();
    }

    private void RotateOnUpdate()
    {
        if (!_isRotating || _interactable.isSelected) return;
        transform
            .Rotate(new Vector3(0f, 30f, 0f) * _rotateSpeed * Time.deltaTime);
    }

    private void StoreInformation()
    {
        OriginalTransform =
            new OriginalTransform {
                originalPosition = transform.position,
                originalScale = transform.localScale,
                originalRotation = transform.rotation.eulerAngles
            };
    }

    public void ResetObjectTransform()
    {
        if (_interactable.isSelected)
        {
            return;
        }
        _interactable
            .transform
            .SetPositionAndRotation(OriginalTransform.originalPosition,
            Quaternion.Euler(OriginalTransform.originalRotation));
        _interactable.transform.localScale = OriginalTransform.originalScale;
    }

    public void ToggleDescription()
    {
        _description.SetActive(!_description.activeSelf);
    }

    public void ToggleObjectRotation()
    {
        _isRotating = !_isRotating;
    }

    public void ShowStringDescription(string desc)
    {
        TMP_Text t = _description.GetComponentInChildren<TMP_Text>();
        if (!t)
        {
            return;
        }
        t.text = desc;
    }

    public void ShowDefaultDescription()
    {
        TMP_Text t = _description.GetComponentInChildren<TMP_Text>();
        if (!t)
        {
            return;
        }
        t.text = DefaultDescription;
    }
}
