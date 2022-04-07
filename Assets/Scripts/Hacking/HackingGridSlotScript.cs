using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingGridSlotScript : MonoBehaviour
{
    public int row;
    public int column;

    public string code;

    HackingMiniGameController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<HackingMiniGameController>();
    }

    public void OnSlotClicked()
    {
        if (code == controller._EasyCombination[0])
        {
            Debug.Log("True");
        }

    }
}
