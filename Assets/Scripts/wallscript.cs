using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallscript : MonoBehaviour
{
    public bool seethrough;
    // Update is called once per frame
    void Start()
    {
        transform.position = new Vector2((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));
    }
}
