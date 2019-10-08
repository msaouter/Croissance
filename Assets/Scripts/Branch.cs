using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    SpriteRenderer spriteBranch;
    List<GameObject> childs;
    Branch parent;

    public List<Vector2> SpawnPoint;

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
