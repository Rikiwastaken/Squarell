using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset Inputcompo;

    public Vector2 movementinput;

    private Vector2 visioninput;

    public float gripinput;

    public bool gripping;

    public float movementspeed;

    public float ReplaceVelocity;

    public bool movedbyice;

    public GameObject triangleNorth;
    public GameObject triangleSouth;
    public GameObject triangleEast;
    public GameObject triangleWest;

    public GameObject activeTriangle;

    public int HP;


    // Start is called before the first frame update
    void Start()
    {
        Inputcompo.FindAction("Move").performed += OnMove;
        Inputcompo.FindAction("Grip").performed += OnGrip;
        Inputcompo.FindAction("Movevision").performed += OnVision;
        activeTriangle = triangleEast;
        activeTriangle.SetActive(true);
        HP = 3;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        movementinput = context.ReadValue<Vector2>();
    }

    public void OnVision(InputAction.CallbackContext context)
    {

        visioninput = context.ReadValue<Vector2>();
    }

    public void OnGrip(InputAction.CallbackContext context)
    {
        gripinput = context.ReadValue<float>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!Inputcompo.FindAction("Move").IsPressed())
        {
            movementinput = Vector2.zero;
        }

        if (!Inputcompo.FindAction("Movevision").IsPressed())
        {
            visioninput = Vector2.zero;
        }

        if (!Inputcompo.FindAction("Grip").IsPressed())
        {
            gripinput = 0f;
        }

        if(gripinput != 0f)
        {
            gripping = true;
        }
        else
        {
            gripping = false;
        }


        ManageDirection();


        if (movementinput == Vector2.zero)
        {
            if(!GetComponentInChildren<MovedScript>().moved && !movedbyice)
            {
                Replace(transform, ReplaceVelocity);
            }
            GetComponent<Animator>().SetBool("Moving", false);
        }
        else
        {

            
            if(!movedbyice)
            {
                GetComponent<Rigidbody2D>().velocity = movementinput * movementspeed;
            }
            GetComponent<Animator>().SetBool("Moving", true);



        }
    }



    public void Replace(Transform tomove, float speed)
    {
        Vector2 Destination = new Vector2((int)Mathf.Round(tomove.position.x), (int)Mathf.Round(tomove.position.y));

        if(Vector2.Distance(tomove.position, Destination)>0.0001f)
        {
            tomove.GetComponent<Rigidbody2D>().velocity = (Destination - (Vector2)tomove.position) * speed;
        }
        else
        {
            tomove.position = new Vector2((int)Mathf.Round(tomove.position.x), (int)Mathf.Round(tomove.position.y));
        }
    }

    void ManageDirection()
    {
        if (visioninput.x >= 0.75f && activeTriangle != triangleEast)
        {
            activeTriangle.SetActive(false);
            activeTriangle = triangleEast;
            activeTriangle.SetActive(true);
        }
        else if (visioninput.x <= -0.75f && activeTriangle != triangleWest)
        {
            activeTriangle.SetActive(false);
            activeTriangle = triangleWest;
            activeTriangle.SetActive(true);
        }
        else if (visioninput.y >= 0.75f && activeTriangle != triangleNorth)
        {
            activeTriangle.SetActive(false);
            activeTriangle = triangleNorth;
            activeTriangle.SetActive(true);
        }
        else if (visioninput.y <= -0.75f && activeTriangle != triangleSouth)
        {
            activeTriangle.SetActive(false);
            activeTriangle = triangleSouth;
            activeTriangle.SetActive(true);
        }
    }


}
