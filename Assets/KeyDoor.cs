using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    private Info Info;

    private bool opendoor;

    private void Start()
    {
        Info = GameObject.Find("Info").GetComponent<Info>();
        GetComponent<Animator>().speed = 0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<PlayerMovement>() != null)
        {
            if(Info.HeldKeys>0)
            {
                Info.HeldKeys--;
                
                GetComponent<Animator>().speed = 1f;
                opendoor = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if(opendoor && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
