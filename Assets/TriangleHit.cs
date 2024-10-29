using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriangleHit : MonoBehaviour
{
    public ArrayList hitlist = new ArrayList();

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(!hitlist.Contains(collision.gameObject))
        {
            hitlist.Add(collision.gameObject);
        }
        Debug.Log(transform.name + " collided with " + collision.gameObject.name + " taille : " + hitlist.Count);
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
