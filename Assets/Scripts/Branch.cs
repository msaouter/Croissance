using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    SpriteRenderer spriteBranch;
    List<GameObject> childs = new List<GameObject>();
    GameObject parent;

    public List<Vector2> SpawnPoint;
    public Vector2 rootPoint;

    float scale;

    float angleStep = 0.05f;
    float angleStepSign = 1;
    float angleBounds = 5;
    float angleAnimation;

    float randomSpeed;

    float defaultHeight;
    float defaultWidth;
    
    void Start()
    {
        scale = 1f;

        defaultHeight = transform.localScale.y;
        defaultWidth = transform.localScale.x;

        spriteBranch = GetComponent<SpriteRenderer>();

        angleAnimation = angleBounds;

        randomSpeed = Random.Range(0f, 0.1f);
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

    public void RemoveChild(GameObject child)
    {
        childs.Remove(child);
    }

    public void RemoveBranch()
    {
        for (int i = 0; i < childs.Count; i++) {
            childs[i].GetComponent<Branch>().RemoveBranch();
        }

        if (parent != null) parent.GetComponent<Branch>().RemoveChild(gameObject);
        scale = 0f;

        OnScaleChange();

        /* Inté son */
        AkSoundEngine.PostEvent("Music_Kill_Coral", parent);
    }

    private void Update()
    {
        //Scale
        if (parent != null) {
            if (parent.GetComponent<Branch>().scale >= 1f && scale < 1f) {
                scale = scale + (0.1f * Time.deltaTime);
                if (scale > 1f) scale = 1f;
                OnScaleChange();
            }
        }

        //Animation
        Vector3 pivotPoint = new Vector3(
                transform.position.x + rootPoint.x,
                transform.position.y + rootPoint.y,
                0
            );

        transform.RotateAround(
            pivotPoint,
            new Vector3(0, 0, 1),
            angleAnimation * Time.deltaTime * randomSpeed
        );

        angleAnimation = angleAnimation + (angleStepSign * angleStep);

        if (angleAnimation > angleBounds) {
            angleStepSign = -1;
        }
        else if (angleAnimation < -angleBounds) {
            angleStepSign = 1;
        }
    }

    void OnScaleChange()
    {
        transform.localScale = new Vector3(
            defaultWidth * scale,
            defaultHeight * scale,
            1
        );
    }

   /* int ParcoursArbre()
    {
        int degradation = 0;
        ParcoursArbreAux(parent, degradation);

        /* Degradation compte nb Coraux dont scale < 0.8. Conditions de renvoi 
    }

    int ParcoursArbreAux(GameObject currentBranch, int degradation)
    {
        if (currentBranch.GetComponent<Branch>().scale < 0.8)
        {

            return ParcoursArbreAux(childs, degradation + 1);
        }

        return ParcoursArbreAux(childs, degradation);
    } */
}