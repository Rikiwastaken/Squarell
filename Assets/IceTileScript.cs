using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTileScript : MonoBehaviour
{

    public float slidespeed;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            if (Vector2.Distance(other.GetComponent<Rigidbody2D>().velocity,Vector2.zero)>1f)
            {
                other.GetComponent<PlayerMovement>().movedbyice = true;
                Vector2 velocity = Vector2.zero;
                if (Mathf.Abs(other.GetComponent<Rigidbody2D>().velocityX) > 0.1f)
                {
                    velocity.x = other.GetComponent<Rigidbody2D>().velocityX / Mathf.Abs(other.GetComponent<Rigidbody2D>().velocityX);
                }
                else if (Mathf.Abs(other.GetComponent<Rigidbody2D>().velocityY) > 0.1f)
                {
                    velocity.y = other.GetComponent<Rigidbody2D>().velocityY / Mathf.Abs(other.GetComponent<Rigidbody2D>().velocityY);
                }
                other.GetComponent<Rigidbody2D>().velocity = velocity * slidespeed;
            }
            else
            {
                other.GetComponent<PlayerMovement>().movedbyice = false;
            }

        }
        if (other.GetComponent<MovableCube>() != null)
        {
            if (Vector2.Distance(other.GetComponent<Rigidbody2D>().velocity, Vector2.zero) > 1f)
            {
                other.GetComponent<MovableCube>().movedbyice = true;
                Vector2 velocity = Vector2.zero;
                if (Mathf.Abs(other.GetComponent<Rigidbody2D>().velocityX) > 0.1f)
                {
                    velocity.x = other.GetComponent<Rigidbody2D>().velocityX / Mathf.Abs(other.GetComponent<Rigidbody2D>().velocityX);
                }
                else if (Mathf.Abs(other.GetComponent<Rigidbody2D>().velocityY) > 0.1f)
                {
                    velocity.y = other.GetComponent<Rigidbody2D>().velocityY / Mathf.Abs(other.GetComponent<Rigidbody2D>().velocityY);
                }
                other.GetComponent<Rigidbody2D>().velocity = velocity * slidespeed;
            }
            else
            {
                other.GetComponent<MovableCube>().movedbyice = false;
            }

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            if(!Checkifthereisanothertile(other.GetComponent<Rigidbody2D>().velocity))
            {
                other.GetComponent<PlayerMovement>().movedbyice = false;
            }
        }
        if (other.GetComponent<MovableCube>() != null)
        {
            if (!Checkifthereisanothertile(other.GetComponent<Rigidbody2D>().velocity))
            {
                other.GetComponent<MovableCube>().movedbyice = false;
                other.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
            }
        }
    }


    bool Checkifthereisanothertile(Vector2 direction)
    {
        bool tilepresent=false;

        Vector2 pos = transform.position;

        IceTileScript[] allicetiles = FindObjectsByType<IceTileScript>(FindObjectsSortMode.None);
        foreach(IceTileScript IceTile in allicetiles)
        {
            Vector2 tilepos = IceTile.transform.position;
            float diffx = tilepos.x - pos.x;
            float diffy = tilepos.y - pos.y;
            if(direction.x>0 && diffx>0.95f && diffx<1.05f && Mathf.Abs(diffy)<0.1f)
            {
                tilepresent = true;
            }
            else if(direction.x < 0 && diffx < -0.95f && diffx > -1.05f && Mathf.Abs(diffy) < 0.1f)
            {
                tilepresent = true;
            }
            else if (direction.y > 0 && diffy > 0.95f && diffy < 1.05f && Mathf.Abs(diffx) < 0.1f)
            {
                tilepresent = true;
            }
            else if (direction.y < 0 && diffy < -0.95f && diffy > -1.05f && Mathf.Abs(diffx) < 0.1f)
            {
                tilepresent = true;
            }
        }

        return tilepresent;
    }
}
