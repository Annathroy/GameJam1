using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerBelowPlatform = false;
    public static GameManager Instance;
    
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
        timer = timeToSavePeople;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // TODO: Game over
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
    
    private void GameOver()
    {
        
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
