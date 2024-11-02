using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullerScript : MonoBehaviour
{

    private bool grippressed;

    public GameObject target;

    public int direction; // -1 horizontal(x), 1 vertical(y); 

    public int range;

    private GameObject activetriangle;

    private ArrayList activetrianglelist;


    // Update is called once per frame
    void FixedUpdate()
    {
        grippressed = GetComponent<PlayerMovement>().gripping;
        activetriangle = GetComponent<PlayerMovement>().activeTriangle;
        activetrianglelist = activetriangle.GetComponent<TriangleHit>().hitlist;
        if (grippressed)
        {
            direction = activetriangle.GetComponent<TriangleHit>().direction;
            foreach (GameObject go in activetrianglelist)
            {
                if (Vector2.Distance(go.transform.position, transform.position) <= range+0.1f)
                {
                    Debug.Log(go.name);
                    if (target != null)
                    {
                        if (Vector2.Distance(go.transform.position, transform.position) < Vector2.Distance(target.transform.position, transform.position))
                        {
                            target = go;
                            
                        }
                    }
                    else
                    {
                        target = go;
                    }
                }
            }
            if(target != null)
            {
                if (target.GetComponent<wallscript>() != null)
                {
                    target = null;
                }

            }
        }
        else
        {
            direction = 0;
            target = null;
        }
        
    }

}
