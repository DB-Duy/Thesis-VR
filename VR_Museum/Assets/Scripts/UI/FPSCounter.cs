using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public float

            timer,
            refresh,
            avgFramerate;

    string display = " FPS";

    private StringBuilder _strBuilder = new StringBuilder(7);

    private TMP_Text m_Text;

    private void Start()
    {
        m_Text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        //Change smoothDeltaTime to deltaTime or fixedDeltaTime to see the difference
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);

        _strBuilder.Clear();
        _strBuilder.Append(avgFramerate.ToString());
        _strBuilder.Append (display);
        m_Text.text = _strBuilder.ToString();
    }
}
