using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPortal : MonoBehaviour
{

    public GameObject Movable;

    private ArrayList collisionlist = new ArrayList();

    private bool laststate;
    public bool powered;

    private Cable Cable;

    private void Start()
    {
        Cable = GetComponentInChildren<Cable>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if(!collisionlist.Contains(other.gameObject) && Vector2.Distance(other.transform.position, transform.position)<=0.3f)
        {
            collisionlist.Add(other.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (collisionlist.Contains(other.gameObject))
        {
            collisionlist.Remove(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        
        
        if(powered && collisionlist.Count<=1)
        {
            GameObject newmovable = Instantiate(Movable, transform.position, Quaternion.identity);
            collisionlist.Add(newmovable);
        }

        transform.position = new Vector2((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));

        if (Cable != null)
        {
            powered = Cable.powered;

        }

        if (powered != laststate)
        {
            ManageAnim();
        }


        laststate = powered;

    }

    private void ManageAnim()
    {
        Animator animator = GetComponent<Animator>();

        if (powered)
        {
            animator.SetBool("PortalOpen", true);
        }
        else
        {
            animator.SetBool("PortalOpen", false);
        }

    }

    
}
