using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour
{
    public int leaves;
    public int leavesPerPunch;
    public GameObject leavesCounter;
    private UnityEngine.UI.Text leavesCounterText;

    public void Start()
    {
        leavesCounterText = leavesCounter.GetComponent<UnityEngine.UI.Text>();
        updateLeafCount();
    }

    private void updateLeafCount()
    {
        if (leaves == 1)
            leavesCounterText.text = "1 Leaf";
        else
            leavesCounterText.text = leaves + " Leaves";
    }

    public void punch()
    {
        leaves += leavesPerPunch;
        updateLeafCount();
    }
}
