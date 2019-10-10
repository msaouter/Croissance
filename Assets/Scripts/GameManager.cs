using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cam;
    float tours;
    public GameObject Sound;

    int currentDegradationEvent;
    int degradationEvent;

    // Start is called before the first frame update
    void Start()
    {
        tours = 0;
        currentDegradationEvent = 0;
        degradationEvent = -1;
    }

    void GenerateDegradation()
    {
        float degradation = Branch.globalDegradation;

        float state = Branch.globalDegradation / Branch.maxGlobalDegradation; /* ATTENTION, Si la height bouge dans CoralGenerator, la puissance changera */
        Debug.Log(state);

        /* Stade de dégradation 1, 13/64 */
        if (state < 0.2) {
            degradationEvent = 0;
        }

        /* Stade de dégradation 2, 26/64 */
        else if (state >= 0.2 && state < 0.4) {
            degradationEvent = 1;
        }

        /* Stade de dégradation 3, 39/64 */
        else if (state >= 0.4 && state < 0.6) {
            degradationEvent = 2;
        }

        /* Stade de dégradation 4, 52/64 */
        else if (state >= 0.6 && state < 0.8) {
            degradationEvent = 3;
        }

        /* Stade de dégradation 5, 64/64 */
        else if (state >= 0.8 && state <= 1) {
            degradationEvent = 4;
        }


        if (degradationEvent != currentDegradationEvent) {
            switch(degradationEvent) {
                case 0:
                    AkSoundEngine.PostEvent("Music_Degradation_4", Sound);
                    break;
                case 1:
                    AkSoundEngine.PostEvent("Music_Degradation_3", Sound);
                    break;
                case 2:
                    AkSoundEngine.PostEvent("Music_Degradation_2", Sound);
                    break;
                case 3:
                    AkSoundEngine.PostEvent("Music_Degradation_1", Sound);
                    break;
                case 4:
                    AkSoundEngine.PostEvent("Music_Degradation_0", Sound);
                    break;
            }

            Debug.Log(degradationEvent);
            currentDegradationEvent = degradationEvent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            tours = 0;

            Ray ray = cam.ScreenPointToRay(new Vector3(
                Input.touches[0].position.x,
                Input.touches[0].position.y,
                0
            ));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f)) {
                if (hit.transform.gameObject.GetComponent<Branch>() && hit.transform.gameObject.GetComponent<Branch>().parent != null) {
                    /* Inté son */
                    AkSoundEngine.PostEvent("Music_Kill_Coral", Sound);
                    hit.transform.gameObject.GetComponent<Branch>().RemoveBranch();
                }
            }
        }

        else
        {
            /*Debug.Log(tours);*/
            tours += 1f * Time.deltaTime ;
            if (tours >= 10)
            {
                AkSoundEngine.PostEvent("Music_Contemplation", Sound);
            }
        }

        if (Input.GetButtonDown("Fire1")) {
            tours = 0;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                if (hit.transform.gameObject.GetComponent<Branch>() && hit.transform.gameObject.GetComponent<Branch>().parent != null) {
                    /* Inté son */
                    AkSoundEngine.PostEvent("Music_Kill_Coral", Sound);
                    hit.transform.gameObject.GetComponent<Branch>().RemoveBranch();
                }
            }
        }

        GenerateDegradation();
    }
}
