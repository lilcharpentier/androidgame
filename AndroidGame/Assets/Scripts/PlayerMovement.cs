using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour {


    public bool isLeftPressed = false;
    public bool isRightPressed = false;

    public CharacterController controller;

    public Vector3 moveVector;

    public float speed = 5.0f;

    public float gravity = 12.0f;

    public float jumpSpeed = 4.0f;

    public bool isDead = false;

    public float falltimer = 0.0f;

    public float jumpCount = 0.0f;

    public Vector3 moveDirection = Vector3.zero;





	void Start () {

        controller = GetComponent<CharacterController>();

	}


    void Update() {

        

            if (isDead)
            return;


            if (isLeftPressed )
         {

            controller.Move(Vector3.left * speed * Time.deltaTime);

        }
 
         else if ( !isLeftPressed )
         {

            controller.Move(Vector3.forward * 0.01f);

        }


        if (isRightPressed)
        {

            controller.Move(Vector3.right * speed * Time.deltaTime);

        }

        else if (!isRightPressed)

        {

            controller.Move(Vector3.forward * 0.01f);
        }

        falltimer = 0.0f;

        if (controller.isGrounded)
        {


            falltimer = 0.0f;

        }

        else if (!controller.isGrounded)

        {



            falltimer += Time.deltaTime;

            jumpCount += Time.deltaTime;

            controller.Move(Vector3.down * speed * Time.deltaTime);


        }

        if (falltimer >= 3.0f)
        {
            Death();

        }

        jumpCount=0.0f;

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * speed * Time.deltaTime);
              
        controller.Move((Vector3.forward * speed) * Time.deltaTime);


        
    }


    public void SetSpeed(float modifier) {

            speed = 5.0f + modifier;

        }



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy")

            Death();


        if (hit.gameObject.tag == "Power")

            Destroy(hit.gameObject);

    }


    private void Death()
    {

        isDead = true;

        GetComponent<Score>().OnDeath();

       
    }


    public void PlayerMoveUp()
    {
       
        
            moveDirection.y = jumpSpeed;
        

    }


    public void onPointerDownLeftButton()
    {
        isLeftPressed = true;
    }
    public void onPointerUpLeftButton()
    {
        isLeftPressed = false;
    }


    public void onPointerDownRightButton()
    {
        isRightPressed = true;
    }
    public void onPointerUpRightButton()
    {
        isRightPressed = false;
    }

}
