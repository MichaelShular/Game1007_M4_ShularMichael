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
        int range = 0; 
        if (numberOfColors == 5)
        {
            numberOfColors++;
        }
        
        range = Random.Range(0, numberOfColors);
        
        //Debug.Log(range);


        switch (range)
        {
            case 0:
                GetComponent<Image>().color = Color.blue;
                _currentColor = MatchThreeColor.Blue;
                break;
            case 1:
                GetComponent<Image>().color = Color.red;
                _currentColor = MatchThreeColor.Red;
                break;
            case 2:
                GetComponent<Image>().color = Color.green;
                _currentColor = MatchThreeColor.Green;
                break;
            case 3:
                GetComponent<Image>().color = Color.yellow;
                _currentColor = MatchThreeColor.Yellow;
                break;
            case 4:
                GetComponent<Image>().color = Color.magenta;
                _currentColor = MatchThreeColor.Magenta;
                break;
            case 5:
                _isWall = true;
                GetComponent<Image>().sprite = _wall;
                _currentColor = MatchThreeColor.Wall;
                break;
            default:
                break;
        }

    }
}
