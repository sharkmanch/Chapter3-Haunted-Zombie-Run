using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //static means one and only in memory, whoever accessing it its the only one to be accessed.
    // Use this for initialization

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameoverMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject scoreText;
    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    //off you go

    public bool PlayerActive
    {
        get { return playerActive; }

    }
    //creating getters and setters for outsiders to access (prevent outsiders manipulate the data from here outside.
    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //means the current instance.
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //  DontDestroyOnLoad(gameObject);
        Assert.IsNotNull(mainMenu);
    }

    void Start()
    {
        scoreText.SetActive(false);
        //player = GetComponent<GameObject>();
        //u overrode player by giving it an empty gameObject
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerCollided()
    {
        gameOver = true;
        gameoverMenu.SetActive(true);
        //print("hithit");
    }

    public void PlayerStartedGame()
    {

        playerActive = true;
    }

    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
        scoreText.SetActive(true);
    }
    public void OnClick()
    {
        if (player.GetComponent<Rigidbody>() != null)
        {
            player.GetComponent<Rigidbody>().detectCollisions = true;
            player.GetComponent<Transform>().position = new Vector3((float)0, (float)2.5, (float)2.5);
        }
        gameoverMenu.SetActive(false);
        instance.gameStarted = true;
        GameManager.instance.gameOver = false;
        Coin.score = 0;
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void PlayerEndedGame()
    {
        if (gameOver == true)
        {
            print("hit");
            gameoverMenu.SetActive(true);
        }
    }
}
