using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;

public class Star : MonoBehaviour
{

    public Vector2 mvtspeed;
    public float rotation;

    private float lightvalue;

    public AnimatorController Animationtoshow;
    public Sprite SpriteToShow;

    // Update is called once per frame

    private void Start()
    {
        if (Animationtoshow != null)
        {
            GetComponent<Animator>().runtimeAnimatorController = Animationtoshow;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite=SpriteToShow;
            GetComponent<Animator>().enabled = false;
        }
        lightvalue = Random.Range(0, 0.9f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f-lightvalue);
        rotation *= Random.Range(-1f, 1f);
        GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler( new Vector3(0f, 0f, Random.Range(0f, 360f)));
    }
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
