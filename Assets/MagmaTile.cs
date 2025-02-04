using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaTile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().GetDamage();
        }
        if(collision.gameObject.GetComponent<MovableCube>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
