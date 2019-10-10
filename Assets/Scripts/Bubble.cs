using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed;
    public float xVariationSpread;
    public float scaleVariation;
    public float MaxHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y>MaxHeight)
            Destroy(this.gameObject);
        float var = Random.Range(-scaleVariation, scaleVariation);
        this.transform.position += new Vector3(Random.Range(-xVariationSpread,xVariationSpread), speed,0)* Time.deltaTime;
        this.transform.localScale += new Vector3(var, var, 0) * Time.deltaTime;
    }
}
