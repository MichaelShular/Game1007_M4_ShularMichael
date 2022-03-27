using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MatchThreeColor
{
    Blue,
    Red,
    Green,
    Yellow,
    Magenta,
    Wall,
    None
}
public class MatchItemColor : MonoBehaviour
{
    public MatchThreeColor _currentColor;
    public Image _image;
    public int num;
    public Sprite _wall;
    public bool _isWall;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _isWall = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomColor(int numberOfColors)
    {
        if(numberOfColors == 5)
        {
            numberOfColors++;
        }

        int range = Random.Range(0, numberOfColors);
        //Debug.Log(range);

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
            case 3:
                GetComponent<Image>().color = Color.yellow;
                break;
            case 4:
                GetComponent<Image>().color = Color.magenta;
                break;
            case 5:
                _isWall = true;
                GetComponent<Image>().sprite = _wall;
                Debug.Log(_isWall);
                break;
            default:
                break;
        }

    }
}
