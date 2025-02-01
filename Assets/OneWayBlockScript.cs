using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayBlockScript : MonoBehaviour
{

    public float slidespeed;

    public Vector2 direction;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            if (Vector2.Distance(other.GetComponent<Rigidbody2D>().velocity,Vector2.zero)>1f)
            {
                other.GetComponent<PlayerMovement>().movedbyice = true;
                other.GetComponent<Rigidbody2D>().velocity = direction * slidespeed;
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
                other.GetComponent<Rigidbody2D>().velocity = direction * slidespeed;
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

        OneWayBlockScript[] allOWtiles = FindObjectsByType<OneWayBlockScript>(FindObjectsSortMode.None);
        foreach(OneWayBlockScript OWTile in allOWtiles)
        {
            Vector2 tilepos = OWTile.transform.position;
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
        IceTileScript[] allicetiles = FindObjectsByType<IceTileScript>(FindObjectsSortMode.None);
        foreach (IceTileScript IceTile in allicetiles)
        {
            Vector2 tilepos = IceTile.transform.position;
            float diffx = tilepos.x - pos.x;
            float diffy = tilepos.y - pos.y;
            if (direction.x > 0 && diffx > 0.95f && diffx < 1.05f && Mathf.Abs(diffy) < 0.1f)
            {
                tilepresent = true;
            }
            else if (direction.x < 0 && diffx < -0.95f && diffx > -1.05f && Mathf.Abs(diffy) < 0.1f)
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
