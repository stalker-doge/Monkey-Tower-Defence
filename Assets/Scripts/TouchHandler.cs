using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit = new RaycastHit();
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.tag=="Tower")
                    {
                        hit.collider.gameObject.GetComponent<UnitHandler>().ShowMenu();
                    }
                }

            }
        }
    }
}
