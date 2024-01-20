using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private UIPanel GameOverPanel;
    [SerializeField] private UIPanel StartGamePanel;
    [SerializeField] private UIPanel PausePanel;
    public void HideAllPanels()
    {
        StartGamePanel.HidePanel();
        PausePanel.HidePanel();
        GameOverPanel.HidePanel();
    }
    public void StartMenu()
    {
        StartGamePanel.ShowPanel();
        PausePanel.HidePanel();
        GameOverPanel.HidePanel();
    }
    public void PauseMenu()
    {
        StartGamePanel.HidePanel();
        PausePanel.ShowPanel();
        GameOverPanel.HidePanel();
    }
}
