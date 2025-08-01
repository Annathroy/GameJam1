using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject gameOverBadEndingMenu;
    
    public GameObject gameOverNeutralEndingMenu;
    public TMP_Text gameOverNeutralEndingText;
    
    public GameObject gameOverGoodEndingMenu;
    public GameObject gameMenu;
    public GameObject gameOverCrushedEndingMenu;
    public GameObject creditsPanel;
    public GameObject dialogPanel;
    public GameObject trueEndingPanel;

    [SerializeField] private GameObject screwdriverActiveImage;
    [SerializeField] private GameObject dynamiteActiveImage;
    [SerializeField] private GameObject mushroomCloud;

    [Header("Texts")] [SerializeField] private TMP_Text timerText;

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
        
        //StartCoroutine(DelayBadEndingScreen());
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
        
        gameOverNeutralEndingText.text = $"{GameManager.Instance.peopleSaved}";
        gameOverNeutralEndingMenu.SetActive(true);
        
        gameOverGoodEndingMenu.SetActive(false);
    }

    public void ShowGameMenu()
    {
        Time.timeScale = 1f; // Resume the game if it was paused
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

    public void ShowTrueEnding()
    {
        trueEndingPanel.SetActive(true);
        gameMenu.SetActive(false);
    }

    public void ShowCreditsPanel()
    {
        mainMenu.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void ShowMainMenuFromCredits()
    {
        mainMenu.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void UpdateTimerText(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;
        
        timerText.text = $"{minutes:D2}:{remainingSeconds:D2}";
    }

    public void ShowDoorDialog()
    {
        dialogPanel.SetActive(true);
    }

    public void CloseDoorDialog()
    {
        dialogPanel.SetActive(false);
    }

    public void ShowScrewdriverImage()
    {
        screwdriverActiveImage.gameObject.SetActive(true);
    }

    public void ShowDynamiteImage()
    {
        dynamiteActiveImage.gameObject.SetActive(true);
    }
    
    public void HideDynamiteImage()
    {
        dynamiteActiveImage.gameObject.SetActive(false);
    }

    private IEnumerator DelayBadEndingScreen()
    {
        mushroomCloud.SetActive(true);
        yield return new WaitForSeconds(2f);
        mushroomCloud.SetActive(false);
    }
}
