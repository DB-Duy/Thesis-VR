using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomRayInteractor : XRRayInteractor
{
    protected override void TranslateAnchor(Transform rayOrigin, Transform anchor, float directionAmount)
    {
        base.TranslateAnchor(rayOrigin, anchor, directionAmount);
    }
}
