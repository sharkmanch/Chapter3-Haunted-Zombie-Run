using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectM : MonoBehaviour {

	[SerializeField] float objectSpeed = 1;
	private float resetPosition = -23.50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * (objectSpeed * Time.deltaTime));

		if (transform.localPosition.x <= resetPosition) {
			Vector3 newPos = new Vector3 (130, transform.position.y, transform.position.z);
			transform.position = newPos;
		
		}



	}
}
