using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralGenerator : MonoBehaviour
{
    public GameObject coralRoot;

    public GameObject coralIPrefab;
    public GameObject coralYPrefab;

    int height;

    // Start is called before the first frame update
    void Start()
    {
        height = 4;
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        GenerateChilds(coralRoot, height);
    }

    void GenerateChilds(GameObject currentCoral, int currentHeight)
    {
        if (currentHeight == 0) {
            GameObject child = Instantiate(coralIPrefab, currentCoral.transform);
            currentCoral.GetComponent<Branch>().AddChild(child);
            child.transform.localPosition = new Vector3(
                currentCoral.GetComponent<Branch>().SpawnPoint[0].x - child.GetComponent<Branch>().rootPoint.x,
                currentCoral.GetComponent<Branch>().SpawnPoint[0].y - child.GetComponent<Branch>().rootPoint.y,
                0
            );

        }
        if (currentHeight > 1) {
            GameObject childY = Instantiate(coralYPrefab, currentCoral.transform);
            currentCoral.GetComponent<Branch>().AddChild(childY);

            childY.transform.localPosition = new Vector3(
                currentCoral.GetComponent<Branch>().SpawnPoint[0].x - childY.GetComponent<Branch>().rootPoint.x,
                currentCoral.GetComponent<Branch>().SpawnPoint[0].y - childY.GetComponent<Branch>().rootPoint.y,
                0
            );

            GameObject childA = Instantiate(coralIPrefab, childY.transform);
            childY.GetComponent<Branch>().AddChild(childA);

            childA.transform.localPosition = new Vector3(
                childY.GetComponent<Branch>().SpawnPoint[0].x - childA.GetComponent<Branch>().rootPoint.x,
                childY.GetComponent<Branch>().SpawnPoint[0].y - childA.GetComponent<Branch>().rootPoint.y,
                0
            );


            GameObject childB = Instantiate(coralIPrefab, childY.transform);
            childY.GetComponent<Branch>().AddChild(childB);

            childB.transform.localPosition = new Vector3(
                childY.GetComponent<Branch>().SpawnPoint[1].x - childB.GetComponent<Branch>().rootPoint.x,
                childY.GetComponent<Branch>().SpawnPoint[1].y - childB.GetComponent<Branch>().rootPoint.y,
                0
            );

            GenerateChilds(childA, currentHeight - 1);
            GenerateChilds(childB, currentHeight - 1);
        }
    }
}
