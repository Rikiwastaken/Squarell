using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovableCube : MonoBehaviour
{

    private GameObject PlayerCube;

    private Vector2 distance= Vector2.zero;

    private bool justtargetted;

    public int orientation; // 0 all direction, 1 only x, 2 only y

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerCube = GameObject.Find("PlayerCube(Clone)");
        if(PlayerCube == null )
        {
            return;
        }

        if(PlayerCube.GetComponent<PullerScript>().target == gameObject )
        {
            
            if(distance == Vector2.zero)
            {
                distance = new Vector2((int)Mathf.Round(transform.position.x - PlayerCube.transform.position.x), (int)Mathf.Round(transform.position.y - PlayerCube.transform.position.y));
                
            }
            if(!justtargetted)
            {
                justtargetted = true;
                transform.position = (Vector2)PlayerCube.transform.position + distance;
            }
            

            
            if(orientation == 0)
            {
                GetComponent<Rigidbody2D>().velocity = PlayerCube.GetComponent<Rigidbody2D>().velocity;
            }
            else if (orientation == 1)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerCube.GetComponent<Rigidbody2D>().velocity.x, 0);
            }
            else if (orientation == 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, PlayerCube.GetComponent<Rigidbody2D>().velocity.y);
            }


            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;


        }
        else
        {
            justtargetted= false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            distance = Vector2.zero;
            PlayerCube.GetComponent<PlayerMovement>().Replace(transform, PlayerCube.GetComponent<PlayerMovement>().ReplaceVelocity);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<wallscript>() != null)
        {
            PlayerCube.GetComponent<PlayerMovement>().gripinput = 0f;
        }
    }

}
