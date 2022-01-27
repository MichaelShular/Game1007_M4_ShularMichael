using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    private float resourceAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor()
    {
        this.GetComponent<Image>().color = Color.green;
    }
    public void changeColorRed()
    {
        this.GetComponent<Image>().color = Color.red;
    }
    public void setResourceAmount(float amount)
    {
        resourceAmount = amount;
    }
}
