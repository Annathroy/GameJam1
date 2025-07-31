using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerBelowPlatform = false;
    public static GameManager Instance;
    public bool isPlayerTouchingExitDoor = false;
    public bool isTntExploded = false;
    public bool isBoxInTriggerZone = false;
    public bool isBoxDestroyed = false;
    public bool PlayerMovementDisabled { get; private set; } = false;

    [SerializeField] private bool exitedTheDoor;
    
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
    public bool spot1Taken = false;
    public bool spot2Taken = false;
    public bool spot3Taken = false;

    private float timer;

    public PlayerController playerRef;

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
            UIManager.Instance.ShowDoorDialog();
            PlayerMovementDisabled = true;
        }
        
        if (timer <= 0)
        {
            GameOver(true);
        }
    }

    private void StartGame()
    {
        PlayerMovementDisabled = false;
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

    public void GameOver(bool isTimeOut)
    {
        Time.timeScale = 0f;
        UIManager.Instance.ShowGameOverBadEndingMenu();
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

    public void ExitThruDoor()
    {
        UIManager.Instance.CloseDoorDialog();
        GameOver();
    }

    public void ResumePlayerMovement()
    {
        PlayerMovementDisabled = false;
    }

    public void ShowPlayerScrewdriverPopUp()
    {
        StartCoroutine(playerRef.ShowScrewdriverPopUp());
    }

    // public void MoveNPCsToEnd(GameObject[] npcs)
    // {
    //     for (int i = 0; i < npcs.Length; i++)
    //     {
    //         switch (i)
    //         {
    //             case 0:
    //                 transform.position = Vector2.MoveTowards(npcs[i].transform.position, new Vector3(-2f, -4.3f, 0f), 2f * Time.deltaTime);
    //                 break;
    //             case 1:
    //                 transform.position = Vector2.MoveTowards(npcs[i].transform.position, new Vector3(-1f, -4.3f, 0f), 2f * Time.deltaTime);
    //                 break;
    //             case 2:
    //                 transform.position = Vector2.MoveTowards(npcs[i].transform.position, new Vector3(1f, -4.3f, 0f), 2f * Time.deltaTime);
    //                 break;
    //             case 3:
    //                 transform.position = Vector2.MoveTowards(npcs[i].transform.position, new Vector3(2f, -4.3f, 0f), 2f * Time.deltaTime);
    //                 break;
    //             
    //             default:
    //                 break;
    //         }
    //     }
    // }
}
