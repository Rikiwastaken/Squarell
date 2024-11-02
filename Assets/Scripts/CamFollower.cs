using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    private GameObject PlayerCube;


    void FixedUpdate()
    {
        PlayerCube = GameObject.Find("PlayerCube(Clone)");

        if(PlayerCube != null )
        {
            transform.position = new Vector3(PlayerCube.transform.position.x, PlayerCube.transform.position.y,transform.position.z);
        }
    }
}
