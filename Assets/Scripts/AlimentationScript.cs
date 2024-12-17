using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentationScript : MonoBehaviour
{

    public bool isalim;

    public bool powered;

    private ArrayList visitedcables;

    private int cabledelay;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isalim)
        {
            if (Vector2.Distance(collision.transform.position, transform.position) <= 0.1f)
            {
                powered = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!isalim && !collision.transform.GetComponent<TriangleHit>() && !collision.transform.GetComponent<PlayerMovement>())
        {
            powered = false;
        }
        
    }

    private void FixedUpdate()
    {
        if(isalim)
        {
            powered=true;
        }

        transform.position = new Vector2((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));
        if(cabledelay > 0 )
        {
            cabledelay--;
        }
        else
        {
            ManageCables();
        }
        
    }

    void ManageCables()
    {
        cabledelay = (int)(0.1f/Time.deltaTime);
        visitedcables = new ArrayList();
        Cable[] cablelist = GameObject.FindObjectsByType<Cable>(FindObjectsSortMode.None);
        foreach (Cable cable in cablelist)
        {
            cable.Alimentation = null;
        }
        foreach (Cable cable in cablelist)
        {
            foreach(GameObject coll in cable.collisions)
            {
                if (coll == gameObject)
                {
                    SpreadPower(cable.gameObject);
                }
            }
        }
    }

    void SpreadPower(GameObject cable)
    {
        
        visitedcables.Add(cable);
        if (cable.GetComponent<Cable>() != null)
        {
            cable.GetComponent<Cable>().Alimentation = gameObject;
            foreach (GameObject coll in cable.GetComponent<Cable>().collisions)
            {
                if (!visitedcables.Contains(coll))
                {
                    SpreadPower(coll);
                }
            }
        }

    }


}
