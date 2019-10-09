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

    int scale;

    float angleStep = 0.05f;
    float angleStepSign = 1;
    float angleBounds = 5;
    float angleAnimation;

    float randomSpeed;
    
    void Start()
    {
        scale = 100;
        spriteBranch = GetComponent<SpriteRenderer>();

        angleAnimation = (angleBounds);

        randomSpeed = Random.Range(0f, 0.5f);
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

    private void Update()
    {
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
}
