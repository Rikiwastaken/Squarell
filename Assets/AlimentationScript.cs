using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentationScript : MonoBehaviour
{
    public bool powered;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Vector2.Distance(collision.transform.position, transform.position)<=0.1f)
        {
            powered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        powered = false;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));
    }

}
