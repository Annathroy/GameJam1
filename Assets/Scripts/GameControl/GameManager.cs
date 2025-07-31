using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerBelowPlatform = false;
    public static GameManager Instance;
    public bool isPlayerTouchingExitDoor = false;
    public bool isTntExploded = false;
    
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
    public bool isNpcUnscrewed;

    [Header("Game Info")]
    public int peopleSaved = 0;
    [SerializeField] private float timeToSavePeople = 70f;
    public int NpcAtLocation = 0;

    private float timer;

    private void Start()
    {
        StartGame();
        Time.timeScale = 0f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        UIManager.Instance.UpdateTimerText(Mathf.RoundToInt(timer));
        
        if (Input.GetKeyDown(KeyCode.E) && isPlayerTouchingExitDoor)
        {
            GameOver();
        }
        
        if (timer <= 0)
        {
            GameOver();
        }
    }

    private void StartGame()
    {
        peopleSaved = 0;
        NpcAtLocation = 0;
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
    public void PickUpScrewdriver()
    {
        hasDrill = true;
    }

    public bool HasScrewdriver()
    {
        return hasDrill;
    }

    public void PickUpDynamite()
    {
        hasDynamite = true;
    }

    public bool HasDynamite()
    {
        return hasDynamite;
    }
}
