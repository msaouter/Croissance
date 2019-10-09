using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralGenerator : MonoBehaviour
{
    public GameObject coralRoot;

    public List<GameObject> coralIPrefabs;
    public List<GameObject> coralYPrefabs;

    public GameObject coralIPrefab;
    public GameObject coralYPrefab;

    int height;

    // Start is called before the first frame update
    void Start()
    {
        height = 8;
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        GenerateChilds(coralRoot, height, 0, 0);
    }

    void GenerateChilds(GameObject currentCoral, int currentHeight, int angleCoefficient, int zIndex)
    {
        GameObject randCoralIPrefab = coralIPrefabs[Random.Range(0, coralIPrefabs.Count)];
        GameObject randCoralYPrefab = coralYPrefabs[Random.Range(0, coralYPrefabs.Count)];

        if (currentHeight == 0) {
            GameObject child = Instantiate(randCoralIPrefab, currentCoral.transform);
            currentCoral.GetComponent<Branch>().AddChild(child);
            child.transform.localPosition = new Vector3(
                currentCoral.GetComponent<Branch>().SpawnPoint[0].x - child.GetComponent<Branch>().rootPoint.x,
                currentCoral.GetComponent<Branch>().SpawnPoint[0].y - child.GetComponent<Branch>().rootPoint.y,
                zIndex
            );

            Vector3 pivotPoint = new Vector3(
                child.GetComponent<Branch>().rootPoint.x,
                child.GetComponent<Branch>().rootPoint.y,
                0
            );

            child.transform.RotateAround(
                child.transform.TransformPoint(pivotPoint),
                new Vector3(0, 0, 1),
                30
            );

        }
        if (currentHeight > 1) {
            GameObject childY = Instantiate(randCoralYPrefab, currentCoral.transform);
            currentCoral.GetComponent<Branch>().AddChild(childY);

            childY.transform.localPosition = new Vector3(
                currentCoral.GetComponent<Branch>().SpawnPoint[0].x - childY.GetComponent<Branch>().rootPoint.x,
                currentCoral.GetComponent<Branch>().SpawnPoint[0].y - childY.GetComponent<Branch>().rootPoint.y,
                zIndex
            );

            GameObject childA = Instantiate(randCoralIPrefab, childY.transform);
            childY.GetComponent<Branch>().AddChild(childA);

            childA.transform.localPosition = new Vector3(
                childY.GetComponent<Branch>().SpawnPoint[0].x - childA.GetComponent<Branch>().rootPoint.x,
                childY.GetComponent<Branch>().SpawnPoint[0].y - childA.GetComponent<Branch>().rootPoint.y,
                zIndex
            );

            GameObject randCoralIPrefab2 = coralIPrefabs[Random.Range(0, coralIPrefabs.Count)];

            GameObject childB = Instantiate(randCoralIPrefab2, childY.transform);
            childY.GetComponent<Branch>().AddChild(childB);

            childB.transform.localPosition = new Vector3(
                childY.GetComponent<Branch>().SpawnPoint[1].x - childB.GetComponent<Branch>().rootPoint.x,
                childY.GetComponent<Branch>().SpawnPoint[1].y - childB.GetComponent<Branch>().rootPoint.y,
                zIndex
            );

            Vector3 pivotPoint = new Vector3(
                childY.transform.position.x + childY.GetComponent<Branch>().rootPoint.x,
                childY.transform.position.y + childY.GetComponent<Branch>().rootPoint.y,
                0
            );

            childY.transform.RotateAround(
                pivotPoint,
                new Vector3(0, 0, 1),
                20 * angleCoefficient
            );

            GenerateChilds(childA, currentHeight - 1, 1, zIndex - 1);
            GenerateChilds(childB, currentHeight - 1, -1, zIndex + 1);
        }
    }
}
