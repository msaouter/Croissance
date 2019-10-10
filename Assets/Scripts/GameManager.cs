using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cam;
    int tours;

    // Start is called before the first frame update
    void Start()
    {
        tours = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Ray ray = cam.ScreenPointToRay(new Vector3(
                Input.touches[0].position.x,
                Input.touches[0].position.y,
                0
            ));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f)) {
                hit.transform.gameObject.GetComponent<Branch>().RemoveBranch();
            }
        }

        else
        {
            tours += 1;
            if (tours >= 540)
            {
                /*AkSoundEngine.PostEvent("Music_Contemplation",  /* Trouver un GameObject à remettre );*/
            }
        }

        if (Input.GetButtonDown("Fire1")) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                hit.transform.gameObject.GetComponent<Branch>().RemoveBranch();
            }
        }
    }
}
