using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesGenerator : MonoBehaviour
{

    public List<GameObject> bubble;
    public int randomIndex;
    public float averageSecondsBetweenBubbles;
    public float BubbleStartingPositionRange;
    public float bubbleSpeed;
    public float spreadBubbleSpeed;
    public float bubbleXVariationSpread;
    public float bubbleScaleVariation;
    public float ScaleVariationSpreadRange;
    public float MaxHeight;

    // Start is called before the first frame update
    void Start()
    {
        randomIndex = Random.Range(0, bubble.Capacity);
        bubble[randomIndex].GetComponent<Bubble>().MaxHeight = this.MaxHeight;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(randomIndex);

        if (Random.Range(0f,1f)<(1/averageSecondsBetweenBubbles * Time.deltaTime))
        {           
            bubble[randomIndex].GetComponent<Bubble>().speed = bubbleSpeed+ Random.Range(-spreadBubbleSpeed,spreadBubbleSpeed);
            bubble[randomIndex].GetComponent<Bubble>().xVariationSpread = bubbleXVariationSpread;
            bubble[randomIndex].GetComponent<Bubble>().scaleVariation = bubbleScaleVariation + Random.Range(-ScaleVariationSpreadRange, ScaleVariationSpreadRange);
            
            GameObject randomBubble = Instantiate<GameObject>(bubble[randomIndex], this.transform.position + new Vector3(Random.Range(-BubbleStartingPositionRange, BubbleStartingPositionRange),
                Random.Range(-BubbleStartingPositionRange, BubbleStartingPositionRange), Random.Range(-BubbleStartingPositionRange, BubbleStartingPositionRange)),
                Camera.main.transform.rotation);

            randomIndex = Random.Range(0, bubble.Capacity);
        }

    }
}
