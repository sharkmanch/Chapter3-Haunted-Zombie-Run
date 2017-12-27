using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
    Animator anim;
    [SerializeField] float pushingForce = 50f;
    [SerializeField] float jumpForce = 100f;
    private Rigidbody rigidBody;

    private bool jump = false;
    private bool fly = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    //no good to use update for games coz it differs from different devices.

    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            anim.Play("jump");
            rigidBody.useGravity = true;
            jump = true;
        }

        //removable test jump front
        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("jump");
            rigidBody.useGravity = true;
            jump = true;
            fly = true;
        }
        // removable test jump front
    }

    void FixedUpdate(){
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

        print(rigidBody.velocity.y);
        }
	}
 
