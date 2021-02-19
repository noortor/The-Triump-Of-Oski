using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainLeafText : MonoBehaviour
{
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = rectTransform.position + new Vector3(0, 60 * Time.deltaTime, 0);
    }
}
