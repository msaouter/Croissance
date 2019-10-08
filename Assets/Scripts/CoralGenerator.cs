using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralGenerator : MonoBehaviour
{
    Transform coralRoot;

    public GameObject coralIPrefab;
    public GameObject coralYPrefab;

    int height;

    // Start is called before the first frame update
    void Start()
    {
        height = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {

    }

    void GenerateChilds(GameObject currentCoral, int currentHeight)
    {
        if (currentHeight == 0) {
            GameObject child = Instantiate(coralIPrefab, currentCoral.transform);
            child.AddComponent<Branch>();
            currentCoral.GetComponent<Branch>().AddChild(child);

        }
        if (currentHeight > 1) {
            GameObject childY = Instantiate(coralYPrefab, currentCoral.transform);
            childY.AddComponent<Branch>();
            currentCoral.GetComponent<Branch>().AddChild(childY);

            GameObject childA = Instantiate(coralIPrefab, childY.transform);
            childA.AddComponent<Branch>();
            childY.GetComponent<Branch>().AddChild(childA);

            GameObject childB = Instantiate(coralIPrefab, childY.transform);
            childB.AddComponent<Branch>();
            childY.GetComponent<Branch>().AddChild(childB);

            GenerateChilds(childA, currentHeight - 1);
            GenerateChilds(childB, currentHeight - 1);
        }
    }
}
