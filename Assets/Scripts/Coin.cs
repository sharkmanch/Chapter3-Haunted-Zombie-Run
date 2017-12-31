using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ObjectM
{
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    [SerializeField] private AudioClip sfxCoin;
    // [SerializeField] private GameObject theCoin;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame


    protected override void Update()
    {
        if (GameManager.instance.PlayerActive)
        {
            base.Update();

        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            //  rigidBody.AddForce(new Vector2(0, 0), ForceMode.Impulse);
            audioSource.PlayOneShot(sfxCoin);
            Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
            transform.position = newPos;
            //rigidBody.detectCollisions = false;
            // turn the detection back to false so it can detect again after one collision.

        }

    }
}
