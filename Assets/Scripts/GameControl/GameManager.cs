using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerBelowPlatform = false;
    public static GameManager Instance;
    public bool isPlayerTouchingExitDoor = false;


    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    [Header("Items")]
    [SerializeField] private bool hasDrill;
    [SerializeField] private bool hasDynamite;
    
    [Header("Game Info")]
    [SerializeField] private int peopleSaved = 0;
    [SerializeField] private float timeToSavePeople = 30f;

    private float timer;

    private void Start()
    {
        StartGame();
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPlayerTouchingExitDoor)
            {
                GameOver();
            }
        }
        timer -= Time.deltaTime;

        UIManager.Instance.UpdateTimerText(Mathf.RoundToInt(timer));
        
        if (timer <= 0)
        {
            GameOver();
        }
    }

    private void StartGame()
    {
        peopleSaved = 0;
        timer = timeToSavePeople;
        hasDrill = false;
        hasDynamite = false;

    }
    
    public void GameOver()
    {
        Time.timeScale = 0f;
        if (peopleSaved <= 0) UIManager.Instance.ShowGameOverBadEndingMenu();
        else if (peopleSaved > 0 && peopleSaved < 4) UIManager.Instance.ShowGameOverNeutralEndingMenu();
        else if (peopleSaved == 4) UIManager.Instance.ShowGameOverGoodEndingMenu();
    }

    /// <summary>
    /// Sets the <see cref="hasDrill"/> variable to true
    /// </summary>
    public void PickUpDrill()
    {
        hasDrill = true;
    }

    public void PickUpDynamite()
    {
        hasDynamite = true;
    }
}
