using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralGenerator : MonoBehaviour
{
    Transform coralRoot;
    public GameObject coralPrefab;

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
        if (currentHeight < 1) {
            GameObject childA = Instantiate(coralPrefab, currentCoral.transform);
            childA.AddComponent<Branch>();
            currentCoral.GetComponent<Branch>().AddChild(childA);

            GameObject childB = Instantiate(coralPrefab, currentCoral.transform);
            childB.AddComponent<Branch>();
            currentCoral.GetComponent<Branch>().AddChild(childB);

            //GenerateChilds(currentHeight - 1);
        }
    }
}
