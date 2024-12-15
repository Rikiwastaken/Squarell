using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public int direction; //0 North, 1 South, 2 East, 3 West

    public float forceStrength;

    public Vector2 ForceVector;

    public bool powered;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.GetComponent<Rigidbody2D>() != null)
        {
            if(powered)
            {

                if(other.GetComponent<PlayerMovement>())
                {

                    Vector2 moveinput = other.GetComponent<PlayerMovement>().movementinput;

                    if (moveinput != Vector2.zero)
                    {
                        other.GetComponent<Rigidbody2D>().velocity = (ForceVector) + moveinput * other.GetComponent<PlayerMovement>().movementspeed;
                        
                    }
                    else
                    {
                        if (direction <= 1)
                        {
                            other.GetComponent<Rigidbody2D>().velocity = (ForceVector);
                        }
                        else
                        {
                            other.GetComponent<Rigidbody2D>().velocity = (ForceVector);
                        }
                    }
                }
                else
                {
                    if (direction <= 1)
                    {
                        other.GetComponent<Rigidbody2D>().velocity = (ForceVector);
                        other.transform.position = new Vector2(transform.position.x, other.transform.position.y);
                    }
                    else
                    {
                        other.GetComponent<Rigidbody2D>().velocity = (ForceVector);
                        other.transform.position = new Vector2(other.transform.position.x, transform.position.y);
                    }
                }

                
                
            }
            
        }
    }

    private void Start()
    {
        if(direction == 0)
        {
            ForceVector =  new Vector2(0f, forceStrength);
        }
        else if(direction == 1)
        {
            ForceVector = new Vector2(0f, -forceStrength);
        }
        else if (direction == 2)
        {
            ForceVector = new Vector2(forceStrength,0f);
        }
        else if (direction == 3)
        {
            ForceVector = new Vector2(-forceStrength,0f);
        }

        GameObject[] ListConveyors=GameObject.FindGameObjectsWithTag("conveyor");
        foreach (GameObject Conveyor in ListConveyors)
        {
            Conveyor.GetComponent<Animator>().Play("ConveyorBelt", -1, 0);
        }

    }


    private void FixedUpdate()
    {
        transform.position = new Vector2((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));

        if(GetComponentInChildren<Cable>().Alimentation!=null)
        {
            powered = GetComponentInChildren<Cable>().Alimentation.GetComponent<AlimentationScript>().powered;
        }
        else
        {
            powered = false;
        }

        if(powered)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }

    }
}
