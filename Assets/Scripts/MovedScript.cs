using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedScript : MonoBehaviour
{

    public bool moved;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<ConveyorBelt>()!=null)
        {
            if(collision.transform.GetComponent<ConveyorBelt>().powered)
            {
                moved = true;
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<ConveyorBelt>() != null)
        {
            moved = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<ConveyorBelt>() != null)
        {
            if (collision.transform.GetComponent<ConveyorBelt>().powered)
            {
                moved = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<ConveyorBelt>() != null)
        {
            moved = false;
        }
    }
}
