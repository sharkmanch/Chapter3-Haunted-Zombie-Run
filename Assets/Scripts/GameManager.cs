using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //static means one and only in memory, whoever accessing it its the only one to be accessed.
    // Use this for initialization

    [SerializeField] private GameObject mainMenu;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;



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
        DontDestroyOnLoad(gameObject);
        Assert.IsNotNull(mainMenu);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerCollided()
    {
        gameOver = true;
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
    }
}
