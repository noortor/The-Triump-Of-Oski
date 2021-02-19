using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeafManager : MonoBehaviour
{
    public int leaves;
    [SerializeField]
    private int leavesPerPunch;
    public GameObject leavesCounter;
    public GameObject leafText;
    public GameObject leavesPerPunchObj;
    private TextMeshProUGUI leavesCounterText;
    private TextMeshProUGUI leavesPerPunchText;
    private Canvas canvas;

    public void Start()
    {
        leavesCounterText = leavesCounter.GetComponent<TextMeshProUGUI>();
        leavesPerPunchText = leavesPerPunchObj.GetComponent<TextMeshProUGUI>();
        canvas = FindObjectOfType<Canvas>();
        updateLeafCount();
        leavesPerPunchText.text = "" + leavesPerPunch;
    }

    private void updateLeafCount()
    {
        leavesCounterText.text = leaves + "";
    }

    public void punch()
    {
        leaves += leavesPerPunch;
        updateLeafCount();
        GameObject myText = Instantiate(leafText, transform.position, transform.rotation);
        myText.transform.SetParent(canvas.transform);
        myText.GetComponent<RectTransform>().position = Input.mousePosition;
        myText.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "+" + leavesPerPunch;
    }

    public int getLeavesPerPunch()
    {
        return leavesPerPunch;
    }

    public void setLeavesPerPunch(int amt)
    {
        leavesPerPunch = amt;
        leavesPerPunchText.text = "" + leavesPerPunch;
    }
}
