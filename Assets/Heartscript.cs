using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartscript : MonoBehaviour
{
    private Info Info;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            if(collision.GetComponent<PlayerMovement>().HP<3)
            {
                collision.GetComponent<PlayerMovement>().HP++;
                Destroy(gameObject);
            }
            
        }
    }
}
