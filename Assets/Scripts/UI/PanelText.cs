using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelText : MonoBehaviour
{
    private TextMeshProUGUI panelText;
    private void Awake()
    {
        panelText = GetComponent<TextMeshProUGUI>();
    }
    public virtual void UpdateText(string _newText)
    {
        if (panelText == null) return;

        panelText.text = _newText;
    }
}
