using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovableCube : MonoBehaviour
{

    private GameObject PlayerCube;

    private Vector2 distance= Vector2.zero;

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
            

            transform.position = (Vector2)PlayerCube.transform.position + distance;

            
        }
        else
        {
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
