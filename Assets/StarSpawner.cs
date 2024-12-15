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

    void Start()
    {

        for(int i = 0; i < nbrang; i++)
        {
            for(int j = 0; j < starparrang; j++)
            {
                float posx= (float)(i+1) / (float)nbrang;
                float posy = (float)(j + 1) / (float)starparrang;
                Vector2 position = new Vector2((posx * 40) - 20, (posy * 20) - 10) + new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)) ;
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
                newstar.transform.localScale = Vector2.one*size;
                newstar.transform.parent = transform;
            }
        }
    }

}
