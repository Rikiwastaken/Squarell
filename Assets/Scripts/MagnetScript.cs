using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    private bool laststate;
    public bool powered;
    private Cable Cable;

    public float dragstrength;

    private void Start()
    {
        Cable = GetComponentInChildren<Cable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<MovedScript>() != null && powered && !GetComponent<PlayerMovement>() && other.GetComponent<Rigidbody2D>())
        {
            Debug.Log(Vector2.Distance(transform.position, other.transform.position));
            Vector2 pullvector = CalculatePullVector(other.transform);
            if(Mathf.Abs(other.transform.position.x - pullvector.x)<=0.01f)
            {
                pullvector.x *=-1;
            }
            if (Mathf.Abs(other.transform.position.y - pullvector.y) <= 0.01f)
            {
                pullvector.y *= -1;
            }
            if ( Vector2.Distance(transform.position, other.transform.position)>1.1f)
            {
                other.GetComponent<Rigidbody2D>().velocity += pullvector*Time.deltaTime;
            }
            if (Vector2.Distance(transform.position, other.transform.position)<=1f && (Mathf.Abs(transform.position.x - other.transform.position.x)<=0.01f || Mathf.Abs(transform.position.y - other.transform.position.y) <= 0.01f))
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<MovedScript>() != null && powered && !other.GetComponentInParent<PlayerMovement>() && !other.GetComponent<PlayerMovement>() && other.GetComponent<Rigidbody2D>())
        {
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
        }
    }

    private void FixedUpdate()
    {

        transform.position = new Vector2((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));

        if (Cable != null)
        {
            powered = Cable.powered;
            
        }

        if(powered !=laststate)
        {
            ManageAnim();
        }


        laststate = powered;

    }

    private void ManageAnim()
    {
        Animator animator = GetComponent<Animator>();

        if(powered)
        {
            animator.SetBool("Powered", true);
        }
        else
        {
            animator.SetBool("Powered", false);
        }

    }

    Vector2 CalculatePullVector(Transform obj)
    {
        Vector2 pullvector = Vector2.zero;
        if(obj.position.x > transform.position.x)
        {
            pullvector.x = -1;
        }
        else
        {
            pullvector.x = 1;
        }

        if (obj.position.y > transform.position.y)
        {
            pullvector.y = -1;
        }
        else
        {
            pullvector.y = 1;
        }

        pullvector *= dragstrength;


        return pullvector;
    }

}
