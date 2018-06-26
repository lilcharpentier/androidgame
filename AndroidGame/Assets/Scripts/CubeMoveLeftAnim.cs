using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveLeftAnim : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {

            anim.Play("LeftMov");


        }

        //anim.Play("CubeMovement");


	}
}
