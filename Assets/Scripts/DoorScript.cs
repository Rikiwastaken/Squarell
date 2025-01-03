using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool laststate;
    private bool powered;
    private Cable Cable;

    private void Start()
    {
        Cable = GetComponentInChildren<Cable>();
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
            animator.SetBool("DoorOpen",true);
            animator.SetBool("DoorClose", false);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            animator.SetBool("DoorOpen", false);
            animator.SetBool("DoorClose", true);
            GetComponent<BoxCollider2D>().enabled = true;
        }

    }

}
