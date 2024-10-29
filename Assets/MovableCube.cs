using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCube : MonoBehaviour
{

    private GameObject PlayerCube;

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
            if(PlayerCube.GetComponent<PullerScript>().direction==1f)
            {
                transform.position = new Vector2(transform.position.x, PlayerCube.transform.position.y);
            }
            else if (PlayerCube.GetComponent<PullerScript>().direction == -1f)
            {
                transform.position = new Vector2(PlayerCube.transform.position.x, transform.position.y);
            }
            else
            {
                PlayerCube.GetComponent<PlayerMovement>().Replace();
            }
        }
        else
        {
            PlayerCube.GetComponent<PlayerMovement>().Replace();
        }


    }
}
