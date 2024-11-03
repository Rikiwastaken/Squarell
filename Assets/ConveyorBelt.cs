using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public int direction; //0 North, 1 South, 2 East, 3 West

    public float forceStrength;

    public Vector2 ForceVector;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.GetComponent<Rigidbody2D>() != null)
        {
            Debug.Log(other.name);
            other.GetComponent<Rigidbody2D>().velocity=(ForceVector);
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
    }


    void FixedUpdate()
    {
        transform.position = new Vector2((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));
    }
}
