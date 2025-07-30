using UnityEngine;

public class UIManager : MonoBehaviour

{
    public static UIManager Instance;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject gameOverBadEndingMenu;
    public GameObject gameOverNeutralEndingMenu;
    public GameObject gameOverGoodEndingMenu;
    public GameObject gameMenu;
    public GameObject gameOverCrushedEndingMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public void ShowMainMenu()
    {
        Debug.Log("Showing Main Menu");
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        gameOverBadEndingMenu.SetActive(false);
        gameOverNeutralEndingMenu.SetActive(false);
        gameOverGoodEndingMenu.SetActive(false);
    }
    public void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        gameOverBadEndingMenu.SetActive(false);
        gameOverNeutralEndingMenu.SetActive(false);
        gameOverGoodEndingMenu.SetActive(false);
    }
    public void ShowGameOverBadEndingMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameOverBadEndingMenu.SetActive(true);
        gameOverNeutralEndingMenu.SetActive(false);
        gameOverGoodEndingMenu.SetActive(false);
    }
    public void ShowGameOverGoodEndingMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameOverBadEndingMenu.SetActive(false);
        gameOverNeutralEndingMenu.SetActive(false);
        gameOverGoodEndingMenu.SetActive(true);
    }
    public void ShowGameOverNeutralEndingMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameOverBadEndingMenu.SetActive(false);
        gameOverNeutralEndingMenu.SetActive(true);
        gameOverGoodEndingMenu.SetActive(false);
    }

    public void ShowGameMenu()
    {
        Time.timeScale = 1f; // Resume the game if it was paused
        Debug.Log("Showing Game Menu");
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameOverBadEndingMenu.SetActive(false);
        gameOverNeutralEndingMenu.SetActive(false);
        gameOverGoodEndingMenu.SetActive(false);
        gameMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void ShowGameOverCrushedEndingMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameOverBadEndingMenu.SetActive(false);
        gameOverNeutralEndingMenu.SetActive(false);
        gameOverGoodEndingMenu.SetActive(false);
        gameOverCrushedEndingMenu.SetActive(true);
    }
}
