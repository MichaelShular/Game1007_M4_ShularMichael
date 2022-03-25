using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MatchThreeColor
{
    Blue,
    Red,
    Green
}
public class MatchItemColor : MonoBehaviour
{
    public MatchThreeColor _currentColor;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomColor()
    {
        int range = Random.Range(0, 3);
        Debug.Log(range);

        _currentColor = (MatchThreeColor)range;
        switch (range)
        {
            case 0:
                GetComponent<Image>().color = Color.blue;
                break;
            case 1:
                GetComponent<Image>().color = Color.red;
                break;
            case 2:
                GetComponent<Image>().color = Color.green;
                break;
            default:
                break;
        }

    }
}
