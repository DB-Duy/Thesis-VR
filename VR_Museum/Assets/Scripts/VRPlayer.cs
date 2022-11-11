using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayer : MonoBehaviour
{
    public static VRPlayer player;

    public GameObject leftHand,
        rightHand;

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }
    }
}
