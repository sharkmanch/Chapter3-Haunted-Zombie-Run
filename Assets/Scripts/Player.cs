﻿using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            anim.Play("jump");

        }
	}
}