using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public GameObject Alimentation;

    private ArrayList collisions = new ArrayList();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Cable>()!=null || collision.GetComponent<AlimentationScript>()!=null)
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
        GameObject newalim=null;
        foreach(GameObject GO in collisions)
        {
            if(GO.GetComponent<AlimentationScript>()!=null)
            {
                newalim = GO;
            }
            if(GO.GetComponent<Cable>()!=null)
            {
                if(GO.GetComponent<Cable>().Alimentation!=null)
                {
                    newalim= GO.GetComponent<Cable>().Alimentation;
                }
            }
        }

        Alimentation = newalim;


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
