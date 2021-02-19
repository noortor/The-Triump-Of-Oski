using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{

    #region  GameObject_variables
    public int cost;
    public int multiplier;
    public bool isBought;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        isBought = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void buyItem() {
        Debug.Log(!isBought);
        if (!isBought) {
            isBought = true;
            LeafManager leafManager = FindObjectOfType<LeafManager>();
            leafManager.setLeavesPerPunch(leafManager.getLeavesPerPunch()*multiplier);
            Debug.Log("bought item");
        } else {
            Debug.Log("cannot buy item again");
        }
    }

}