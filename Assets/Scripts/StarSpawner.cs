using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject star;

    public AnimatorController Animationtoshow;
    public Sprite SpriteToShow;

    public int nbrang;
    public int starparrang;

    public Vector2 mvtspeed;
    public float rotation;
    public float size;
    public Vector2 screensize;
    public int shootingstarmax;
    private GameObject starholder;

    void Start()
    {

        starholder = new GameObject("starholder");
        for(int i = 0; i < nbrang; i++)
        {
            for(int j = 0; j < starparrang; j++)
            {
                float posx= (float)(i+1) / (float)nbrang;
                float posy = (float)(j + 1) / (float)starparrang;
                Vector2 position = transform.position = new Vector2((posx * screensize.x) - screensize.x/2, (posy * screensize.y) - screensize.y/2) + new Vector2(Random.Range(-screensize.x/4, screensize.x / 4), Random.Range(-screensize.y / 4, screensize.y / 4)) ;
                GameObject newstar = Instantiate(star, position, Quaternion.identity);
                if (Animationtoshow != null)
                {
                    newstar.GetComponent<Star>().Animationtoshow = Animationtoshow;
                }
                if(SpriteToShow != null)
                {
                    newstar.GetComponent<Star>().SpriteToShow=SpriteToShow;
                }
                newstar.GetComponent<Star>().mvtspeed = mvtspeed;
                newstar.GetComponent<Star>().rotation = rotation;
                newstar.GetComponent<Star>().xtowarp = (screensize.x/2.0f)+1.0f;
                newstar.GetComponent<Star>().ytowarp = (screensize.y / 2.0f) + 1.0f;
                newstar.GetComponent<Star>().shootingstarmax = shootingstarmax;
                newstar.transform.localScale = Vector2.one*size;
                newstar.transform.parent = starholder.transform;
                
            }
        }
    }

    private void FixedUpdate()
    {
        //if (GameObject.Find("Main Camera"))
        //{
        //    transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x, GameObject.Find("Main Camera").transform.position.y, transform.position.z);
        //    starholder.transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x, GameObject.Find("Main Camera").transform.position.y, starholder.transform.position.z);
        //}
    }

}
