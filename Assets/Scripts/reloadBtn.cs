using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadBtn : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void restartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
