using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    SpriteRenderer spriteBranch;
    List<GameObject> childs;
    GameObject parent;

    int spawnX;
    int spawnY;

    int scale;
    
    void Start()
    {
        childs = new List<GameObject>();

        scale = 100;
        spriteBranch = GetComponent<SpriteRenderer>();
    }

    public void SetParent(GameObject parent)
    {
        this.parent = parent;
    }

    public void AddChild(GameObject child)
    {
        childs.Add(child);
        child.GetComponent<Branch>().SetParent(gameObject);
    }
}
