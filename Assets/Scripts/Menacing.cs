using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menacing : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectTransform;
    Vector3 initialPos;
    int flickerFrames = 15;
    float vertDist = 7f;
    float horiDist = 4f;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        initialPos = rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        int stage = (int) (now * flickerFrames) % 4;
        switch (stage)
        {
            case 0:
                rectTransform.position = initialPos;
                break;
            case 1:
                rectTransform.position = initialPos + new Vector3(horiDist, 0);
                break;
            case 2:
                rectTransform.position = initialPos + new Vector3(0, vertDist);
                break;
            case 3:
                rectTransform.position = initialPos + new Vector3(horiDist, vertDist);
                break;
        }
    }
}
