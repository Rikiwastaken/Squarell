using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public GameObject Alimentation;

    public ArrayList collisions = new ArrayList();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Cable>()!=null  || collision.GetComponent<AlimentationScript>() != null)
        {
            if (!collisions.Contains(collision.gameObject))
            {
                collisions.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if(collisions.Contains(collision.gameObject))
        {
            collisions.Remove(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
    


        if(Alimentation != null)
        {
            if (Alimentation.GetComponent<AlimentationScript>().powered)
            {
                transform.parent.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                transform.parent.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            transform.parent.GetChild(0).gameObject.SetActive(false);
        }

    }

}
