using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : UIPanel
{
    [SerializeField] private PanelText levelText;
    [SerializeField] private PanelText enemiesText;
    public void UpdateLevelText(int _newLevel)
    {
        levelText.UpdateText("Mission: " + _newLevel.ToString());
    }
    public void UpdateEnemiesText(int _newEnemies)
    {
        enemiesText.UpdateText(" x " + _newEnemies.ToString());
    }
}
