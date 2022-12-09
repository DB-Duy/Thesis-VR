using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsValue : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private TMP_Text _text;
    private StringBuilder _str = new StringBuilder();

    [SerializeField]
    private Slider _slider;

    private void OnValidate()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        UpdateValue();
    }

    public void UpdateValue()
    {
        SetValue(_slider.value);
    }

    public void SetValue(float value)
    {
        _str.Clear();
        _str.Append(value.ToString("#.##"));
        _text.SetText(_str.ToString());
    }

    public void SetValue(string value)
    {
        _text.SetText(value);
    }
}
