using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectTransform;
    UnityEngine.UI.Image image;
    Vector3 initialPos;
    private float flickerFrames = 30;
    int fadeFrames = 150;
    float vertDist = 7f;
    float horiDist = 6f;
    public bool dead = false;
    public GameObject winImage;
    float startFrames = -1;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        image = gameObject.GetComponent<UnityEngine.UI.Image>();
        initialPos = rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            float now = Time.time;
            int stage = (int)(now * flickerFrames) % 4;
            if (startFrames == -1)
            {
                startFrames = now;
            }
            switch (stage)
            {
                case 0:
                    rectTransform.position = initialPos;
                    break;
                case 1:
                    rectTransform.position = initialPos + new Vector3(horiDist, 0);
                    break;
            }

            image.color = new Color32(255, 0, 0, (byte) Mathf.Max(0, 255 - (now - startFrames) * fadeFrames));
            // Debug.Log((now - startFrames) * fadeFrames);
            if (255 - (now - startFrames) * fadeFrames <= 0)
                winImage.SetActive(true);
        }
    }
}
