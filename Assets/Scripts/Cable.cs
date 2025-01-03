using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{

    public bool powered;

    public GameObject Alimentation;

    public GameObject PreviousCable;

    public ArrayList collisions = new ArrayList();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<AlimentationScript>() != null)
        {
            Alimentation = collision.gameObject;
        }
        if (collision.GetComponent<Cable>() != null && PreviousCable == null)
        {
            GameObject newprevious = CheckifAlimentationInCables(collision.gameObject);
            if(newprevious != null)
            {
                PreviousCable = newprevious;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if(collision.gameObject==Alimentation)
        {
            powered = false;
            Alimentation = null;
        }
        if(collision.gameObject==PreviousCable)
        {
            powered = false;
            PreviousCable = null;
        }
    }

    private void FixedUpdate()
    {
    
        

        if(Alimentation != null)
        {

            powered = Alimentation.GetComponent<AlimentationScript>().powered;


            if (Alimentation.GetComponent<AlimentationScript>().powered)
            {
                transform.parent.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                transform.parent.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (PreviousCable!=null)
        {
            powered = checkpoweredinpreviouscables(PreviousCable, new HashSet<GameObject>());
        }
        else
        {
            powered = false;
        }

        if (powered)
        {
            transform.parent.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.parent.GetChild(0).gameObject.SetActive(false);
        }

    }


    GameObject CheckifAlimentationInCables(GameObject cable)
    {
        if(cable.GetComponent<Cable>().Alimentation!=null)
        {
            return cable;
        }
        else if(cable.GetComponent<Cable>().PreviousCable != null && cable.GetComponent<Cable>().PreviousCable != gameObject)
        {
            return cable;
        }
        else
        {
            return null;
        }
    }

    bool checkpoweredinpreviouscables(GameObject PreviousCable, HashSet<GameObject> visited)
    {
        if (visited.Contains(PreviousCable))
        {
            return false; // Prevent infinite recursion
        }

        visited.Add(PreviousCable);

        if (PreviousCable.GetComponent<Cable>().Alimentation != null)
        {
            return PreviousCable.GetComponent<Cable>().powered;
        }
        else if (PreviousCable.GetComponent<Cable>().PreviousCable != null)
        {
            return checkpoweredinpreviouscables(PreviousCable.GetComponent<Cable>().PreviousCable, visited);
        }
        else
        {
            return false;
        }
    }


}
