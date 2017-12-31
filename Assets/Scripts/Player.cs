using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
//Assertions here is needed for debugging 
public class Player : MonoBehaviour
{
    Animator anim;
    [SerializeField] float pushingForce = 50f;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;
    //[SerializeField] private AudioClip sfxCoin;

    private Rigidbody rigidBody;

    private bool jump = false;
    private bool fly = false;
    private AudioSource audioSource;

    // Use this for initialization
    void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
        //  Assert.IsNotNull(sfxCoin);
    }
    // assertion is debug method and isnotNull is to detect if theres sth declared but not applied. It will be shown on console as Error.
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //no good to use update for games coz it differs from different devices.

    void Update()
    {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            rigidBody.isKinematic = false;

            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStartedGame();
                anim.Play("jump");
                audioSource.PlayOneShot(sfxJump);
                rigidBody.useGravity = true;
                jump = true;
            }

            //removable test jump front
            if (Input.GetMouseButtonDown(1))
            {

                GameManager.instance.PlayerStartedGame();
                anim.Play("jump");
                rigidBody.useGravity = true;
                audioSource.PlayOneShot(sfxJump);
                jump = true;
                fly = true;
            }
            // removable test jump front
        }
    }

    void FixedUpdate()
    {
        if (jump == true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }


        //removable test jump front
        if (fly == true)
        {
            fly = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(pushingForce, 10f), ForceMode.Impulse);
        }
        // removable test jump front

        // print(rigidBody.velocity.y);
    }
    void OnCollisionEnter(Collision collision)
    {
        // print(collision.gameObject.tag);
        if (collision.gameObject.tag == "obstacle")
        {
            rigidBody.AddForce(new Vector2(-50, 20), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            // turn the detection back to false so it can detect again after one collision.
            audioSource.PlayOneShot(sfxDeath);
            rigidBody.useGravity = false;
            rigidBody.isKinematic = true;
            GameManager.instance.PlayerStartedGame();



            GameManager.instance.PlayerCollided();
            //to stop the map stuff when gameOver is true (written as when gameOver is not true, everything move)
        }
        // this is to detect if the colliding object is tagged with "obstacle". 

    }

}


