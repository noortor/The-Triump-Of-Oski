using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeafManager : MonoBehaviour
{
    public int leaves;
    [SerializeField]
    private int punchBaseStrength = 1;
    private int punchMultiplier = 1;
    public GameObject leavesCounter;
    public GameObject leafText;
    public GameObject leavesPerPunchObj;
    public GameObject oski;
    public GameObject trunk;
    public GameObject branches;
    private bool hasAxe = false;
    private bool dead;
    public Sprite oskiNeutral;
    public Sprite oskiPunch;
    private UnityEngine.UI.Image oskiImage; 
    private TextMeshProUGUI leavesCounterText;
    private TextMeshProUGUI leavesPerPunchText;
    private Canvas canvas;

    public void Start()
    {
        leavesCounterText = leavesCounter.GetComponent<TextMeshProUGUI>();
        leavesPerPunchText = leavesPerPunchObj.GetComponent<TextMeshProUGUI>();
        oskiImage = oski.GetComponent<UnityEngine.UI.Image>();
        canvas = FindObjectOfType<Canvas>();
        updateLeafCount();
        leavesPerPunchText.text = "" + getLeavesPerPunch();
    }

    private int getLeavesPerPunch()
    {
        if (hasAxe)
            return 999999999;
        return punchBaseStrength * punchMultiplier;
    }

    public void updateLeafCount()
    {
        leavesCounterText.text = leaves + "";
    }

    public void punch()
    {
        if (hasAxe)
        {
            trunk.GetComponent<DeathAnimation>().dead = true;
            branches.GetComponent<DeathAnimation>().dead = true;
            if (!dead)
            {
                leaves = 9999999;
                dead = true;
            }
            updateLeafCount();
        }
        else
        {
            leaves += getLeavesPerPunch();
            updateLeafCount();
            GameObject myText = Instantiate(leafText, transform.position, transform.rotation);
            myText.transform.SetParent(canvas.transform);
            myText.GetComponent<RectTransform>().position = Input.mousePosition;
            myText.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "+" + getLeavesPerPunch();
        }
        oskiImage.sprite = oskiPunch;
    }

    public void unPunch()
    {
        oskiImage.sprite = oskiNeutral;
    }

    public int getPunchBaseStrength()
    {
        return punchBaseStrength;
    }

    public void setPunchBaseStrength(int amt)
    {
        punchBaseStrength = amt;
        leavesPerPunchText.text = "" + getLeavesPerPunch();
    }

    public void increasePunchBaseStrength(int amt)
    {
        punchBaseStrength += amt;
        leavesPerPunchText.text = "" + getLeavesPerPunch();
    }

    public int getPunchMultiplier()
    {
        return punchMultiplier;
    }

    public void setPunchMultiplier(int amt)
    {
        punchMultiplier = amt;
        leavesPerPunchText.text = "" + getLeavesPerPunch();
    }

    public void increasePunchMultiplier(int amt)
    {
        punchMultiplier += amt;
        leavesPerPunchText.text = "" + getLeavesPerPunch();
    }

    public void buyAxe()
    {
        hasAxe = true;
        leavesPerPunchText.text = "" + getLeavesPerPunch();
    }
}
