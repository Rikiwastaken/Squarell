using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriangleHit : MonoBehaviour
{
    public ArrayList hitlist = new ArrayList();

    public int direction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!hitlist.Contains(collision.gameObject))
        {
            if(collision.transform.GetComponent<wallscript>() != null)
            {
                if(!collision.transform.GetComponent<wallscript>().seethrough)
                {
                    hitlist.Add(collision.gameObject);
                }
            }
            else
            {
                hitlist.Add(collision.gameObject);
            }
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hitlist.Remove(collision.gameObject);
    }

    private void FixedUpdate()
    {
        if(GetComponentInParent<PlayerMovement>().activeTriangle==gameObject)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
