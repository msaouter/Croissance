using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    SpriteRenderer spriteBranch;
    List<GameObject> childs;
    Branch parent;

    int spawnX;
    int spawnY;

    int scale;
    
    void Start()
    {
        scale = 100;
        spriteBranch = GetComponent<SpriteRenderer>();
    }

    public void AddChild(GameObject child)
    {
        childs.Add(child);
    }
}
