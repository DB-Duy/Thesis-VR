using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Collider))]
public class DescriptionCollider : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private Collider _col;

    public string _description;

    [SerializeField, HideInInspector]
    private InteractableArtefact _artefact;

    private void OnValidate()
    {
        _col = GetComponent<Collider>();
        _artefact = GetComponentInParent<InteractableArtefact>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _artefact.ShowStringDescription (_description);
    }

    private void OnTriggerExit(Collider other)
    {
        _artefact.ShowDefaultDescription();
    }
}
