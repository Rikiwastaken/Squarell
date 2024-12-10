using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public Vector2 mvtspeed;
    public float rotation;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = mvtspeed;
        GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(GetComponent<Rigidbody2D>().transform.rotation.eulerAngles + new Vector3(0f,0f,rotation));
        if(transform.position.x>20)
        {
            transform.position = new Vector2(-20, transform.position.y);
        }
        if (transform.position.x < -20)
        {
            transform.position = new Vector2(20, transform.position.y);
        }
        if (transform.position.y > 12)
        {
            transform.position = new Vector2(transform.position.x, -12);
        }
        if (transform.position.y < -12)
        {
            transform.position = new Vector2(transform.position.x, 12);
        }
    }
}
