using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyscript : MonoBehaviour
{
    private Info Info;

    private void Start()
    {
        Info = GameObject.Find("Info").GetComponent<Info>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            Info.HeldKeys += 1;
            Destroy(gameObject);
        }
    }
}
