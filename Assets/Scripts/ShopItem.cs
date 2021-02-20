using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{

    #region  GameObject_variables
    public float cost;
    public int basePower;
    public int multiplier;
    public int boughtTimes;
    public float priceMultiplier;
    public bool isAxe = false;
    public GameObject priceObj;
    private TextMeshProUGUI priceText;
    private LeafManager leafManager;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        boughtTimes = 0;
        leafManager = GameObject.Find("LeafManager").GetComponent<LeafManager>();
        priceText = priceObj.GetComponent<TextMeshProUGUI>();
        priceText.text = (int) cost + "";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void buyItem() 
    {
        if (leafManager.leaves > cost)
        {
            leafManager.leaves -= (int) cost;
            leafManager.updateLeafCount();
            if (isAxe)
            {
                leafManager.buyAxe();
                return;
            }
            boughtTimes += 1;
            leafManager.increasePunchBaseStrength(basePower);
            leafManager.increasePunchMultiplier(multiplier);
            cost *= priceMultiplier;
            priceText.text = (int)cost + "";
        }
    }

}