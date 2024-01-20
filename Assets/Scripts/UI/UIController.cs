using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField] private MenuUI menuUI;
    [SerializeField] private LevelPanel levelPanel;
    [SerializeField] private StartLevelPanel startLevelPanel;
    public void UpdateUI(GameController.eGameState _newGameState)
    {
        switch (_newGameState)
        {
            case GameController.eGameState.MenuStart:
                menuUI.StartMenu();
                levelPanel.HidePanel();
                startLevelPanel.HidePanel();
                break;
            case GameController.eGameState.PauseGame:
                menuUI.PauseMenu();
                levelPanel.HidePanel();
                startLevelPanel.HidePanel();
                break;
            case GameController.eGameState.StartLevel:
                menuUI.HideAllPanels();
                levelPanel.HidePanel();
                startLevelPanel.ShowPanel();
                break;
            case GameController.eGameState.PlayGame:
                menuUI.HideAllPanels();
                levelPanel.ShowPanel();
                startLevelPanel.HidePanel();
                break;
        }
    }
    public void UpdateLevel(int _newLevel)
    {
        levelPanel.UpdateLevelText(_newLevel);
        startLevelPanel.UpdateLevelText(_newLevel);
    }
    public void UpdateEnemies(int _newEnemies)
    {
        levelPanel.UpdateEnemiesText(_newEnemies);
    }
    public void UpdateLives(int _newLives)
    {
        startLevelPanel.UpdateLivesText(_newLives);
    }
}
