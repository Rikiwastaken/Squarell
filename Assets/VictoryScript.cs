using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerMovement>() && Vector2.Distance(collision.transform.position,transform.position)<0.05f)
        {
            Transform Canvas = GameObject.Find("Canvas").transform;
            int nbchildren=Canvas.childCount;
            for (int i = 0; i < nbchildren; i++)
            {
                Canvas.GetChild(i).gameObject.SetActive(true);
            }
            Time.timeScale = 0.0f;
        }
    }
}
