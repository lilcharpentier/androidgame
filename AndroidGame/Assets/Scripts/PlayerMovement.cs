using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;

    public Vector3 moveVector;

    public float speed = 5.0f;

    public float horizontalSpeed = 20.0f;

    public float verticalVelocity = 0.0f;

    public float gravity = 12.0f;

    public float jumpSpeed = 4.0f;

    private float startTime;

    public bool isDead = false;

    public float timer = 0.0f;

    public float falltimer = 0.0f;

    public float jumpCount = 0.0f;

    public Vector3 moveDirection = Vector3.zero;

    public Component[] comps;


	// Use this for initialization
	void Start () {

        controller = GetComponent<CharacterController>();

  

        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {


        if (isDead)
            return;


        if (controller.isGrounded)
        {


            falltimer = 0.0f;





            if (Input.GetButton("Jump"))

                moveDirection.y = jumpSpeed;


            else if (Input.GetMouseButton(0) && Input.mousePosition.y > Screen.height / 2)

                moveDirection.y = jumpSpeed;

        }

        else

        {

            

            falltimer += Time.deltaTime;

            jumpCount += Time.deltaTime;

            controller.Move(Vector3.down * speed * Time.deltaTime);


        }

        jumpCount=0.0f;

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * speed * Time.deltaTime);



        if (falltimer >= 3f)
        {
            Debug.Log(falltimer);

            Death();
        }
       

       

        controller.Move((Vector3.forward * speed) * Time.deltaTime);


        if (Input.GetMouseButton(0))
        {

            if (Input.mousePosition.x > Screen.width / 2 && (Input.mousePosition.y)<Screen.height/2)

                if (!controller.isGrounded)
                    controller.Move((Vector3.right * speed) * Time.deltaTime);

            else
                if (!controller.isGrounded)
                controller.Move((Vector3.left * speed) * Time.deltaTime);



        }

        if (Input.GetKey("left"))
        {



            if (!controller.isGrounded)
            {
                controller.Move((Vector3.left * speed) * Time.deltaTime);
            }


        }


                

                if (Input.GetKey("right"))
                {

                      if (!controller.isGrounded)
                          {
                controller.Move((Vector3.right * speed) * Time.deltaTime);
                          }
    
                }



            

    

        //moveVector.z = speed;
        


        timer += Time.deltaTime;

        if (timer >= 2.0f)//change the float value here to change how long it takes to switch.
        {
            // pick a random color

            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            // apply it on current object's material

           GetComponent<Renderer>().material.color = newColor;

            timer = 0;
        }


        





    }


    public void SetSpeed(float modifier)

    {

        speed = 5.0f + modifier;


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy")

            Death();

        else

        if (hit.point.z > transform.position.z)
        {

            hit.gameObject.GetComponent<Renderer>().material.color = controller.GetComponent<Renderer>().material.color;

            comps = hit.gameObject.GetComponentsInChildren<Renderer>();

           for(int i=0;i<comps.Length;i++)
            {

                comps[i].GetComponent<Renderer>().material.color= controller.GetComponent<Renderer>().material.color;

            }


        }

    }


 


    private void Death()
    {

        isDead = true;

        GetComponent<Score>().OnDeath();

        Debug.Log("Dead");
    }
}
