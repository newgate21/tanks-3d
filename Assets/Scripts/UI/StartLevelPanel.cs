using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelPanel : UIPanel
{
    [SerializeField] private PanelText levelText;
    [SerializeField] private PanelText livesText;
    public void UpdateLevelText(int _newLevel)
    {
        levelText.UpdateText("Mission: " + _newLevel.ToString());
    }
    public void UpdateLivesText(int _newLives)
    {
        levelText.UpdateText("Lives x " + _newLives.ToString());
    }
}
