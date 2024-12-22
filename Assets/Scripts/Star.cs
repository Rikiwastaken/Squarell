using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Star : MonoBehaviour
{

    public Vector2 mvtspeed;
    public float rotation;

    private float lightvalue;

    public AnimatorController Animationtoshow;
    public Sprite SpriteToShow;

    private int chancetobecomeashootingstar;
    public int shootingstarmax;
    public float xtowarp;
    public float ytowarp;

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
        Vector2 posparent = transform.parent.position;


        if(transform.position.x-posparent.x>xtowarp)
        {
            transform.position = new Vector2(-xtowarp + posparent.x, transform.position.y);
            becomeshootingstar(true);
        }
        else if (transform.position.x - posparent.x < -xtowarp)
        {
            transform.position = new Vector2(xtowarp + posparent.x, transform.position.y);
            becomeshootingstar(true);
        }
        else if (transform.position.y - posparent.y > ytowarp)
        {
            transform.position = new Vector2(transform.position.x, -ytowarp + posparent.y);
            becomeshootingstar(true);
        }
        else if (transform.position.y - posparent.y < -ytowarp)
        {
            transform.position = new Vector2(transform.position.x, ytowarp + posparent.y);
            becomeshootingstar(true);
        }
        else
        {
            becomeshootingstar(false);
        }
        
    }

    void becomeshootingstar(bool move)
    {
        if(move)
        {
            chancetobecomeashootingstar = (int)Random.Range(0, shootingstarmax);
        }
        
        if(chancetobecomeashootingstar==shootingstarmax-3)
        {
            GetComponent<Rigidbody2D>().velocity = mvtspeed*10;
            GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(GetComponent<Rigidbody2D>().transform.rotation.eulerAngles + new Vector3(0f, 0f, rotation*35));
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = mvtspeed;
            GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(GetComponent<Rigidbody2D>().transform.rotation.eulerAngles + new Vector3(0f, 0f, rotation));
        }
    }
}
