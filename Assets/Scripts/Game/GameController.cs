using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    public enum eGameState
    {
        MenuStart,
        PauseGame,
        StartLevel,
        PlayGame,
    }
    [SerializeField] private int initialLives = 3;

    private PlayerTank player;
    private int currentLives;
    private int currentLevel;
    private eGameState gameState = eGameState.MenuStart;
    public bool IsPlayActive() { return gameState == eGameState.PlayGame; }
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float displayTime = 3.0f;
    public PlayerTank Player { get { return player; } }
    [SerializeField] private AudioController audioController;
    public void Start()
    {
        CreatePlayer();
        CreateEnemy();
        GoToState(eGameState.MenuStart);
    }
    public void GoToState(eGameState _state)
    {
        gameState = _state;
        switch (gameState)
        {
            case eGameState.MenuStart:
                Cursor.visible = true;
                PauseGame();
                break;
            case eGameState.PauseGame:
                player.gameObject.SetActive(false);
                Cursor.visible = true;
                PauseGame();
                break;
            case eGameState.StartLevel:
                UIController.Instance.UpdateLevel(currentLevel);
                UIController.Instance.UpdateLives(currentLives);
                UIController.Instance.UpdateEnemies(1);
                StartCoroutine(StartGameSequence());
                break;
            case eGameState.PlayGame:
                player.gameObject.SetActive(true);
                Cursor.visible = false;
                UnpauseGame();
                break;
        }

        UIController.Instance.UpdateUI(gameState);
    }
    void CreatePlayer()
    {
        GameObject playerGO = Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        player = playerGO.GetComponent<PlayerTank>();
        player.gameObject.SetActive(false);
    }
    void CreateEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(-3.5f, 2, 23), Quaternion.identity);
    }
    public void OnPlayerDestroyed()
    {
        currentLives--;
        UIController.Instance.UpdateLives(currentLives);

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            GoToState(eGameState.StartLevel);
        }
    }
    private IEnumerator StartGameSequence()
    {
        PauseGame();

        // Wait for the specified display time
        yield return new WaitForSecondsRealtime(displayTime);

        GoToState(eGameState.PlayGame);
    }
    public void StartNewGameButton()
    {
        currentLives = initialLives;
        currentLevel = 1;
        player.Reset();
        GoToState(eGameState.StartLevel);
    }
    public void ContinueGameButton()
    {
        LoadGame();
        GoToState(eGameState.StartLevel);
    }
    private void LoadGame()
    {
        currentLevel = 1;
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    private void UnpauseGame()
    {
        Time.timeScale = 1;
    }
    public void UnpauseButton()
    {
        GoToState(eGameState.PlayGame);
    }
    public void SaveAndExitButton()
    {
        QuitGameButton();
    }
    public void QuitGameButton()
    { }
    public void RestartGameButton()
    { }
    private void GameOver()
    { }
}