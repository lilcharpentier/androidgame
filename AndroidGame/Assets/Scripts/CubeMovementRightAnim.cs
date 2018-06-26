using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementRightAnim : MonoBehaviour
{

    public Animator anim;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {

            anim.Play("RightMov");


        }

        //anim.Play("CubeMovement");



    }
}
