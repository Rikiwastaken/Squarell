using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void DestroyParent()
    {
        if(transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void SaveScene()
    {
        GameObject.Find("PlayerCursor").GetComponent<PlayerCursorEditorScript>().SaveLevel();
    }
}
