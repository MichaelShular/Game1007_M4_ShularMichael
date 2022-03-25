using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchThreeGameController : MonoBehaviour
{
    public int _gridSize;
    //public int gridYSize;
    public GameObject _MatchThreeObject;

    // Start is called before the first frame update
    void Start()
    {
        creatingGameBoard();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void creatingGameBoard()
    {
        float boardSize = _gridSize * 20 + (_gridSize - 1 * 2);
        float bottomLimit = 0 - boardSize / 2;
        

        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                GameObject temp = Instantiate(_MatchThreeObject, this.transform);
                temp.transform.localPosition = new Vector3(bottomLimit + 22 * i, 100 + 22 * j, 0);
                temp.GetComponent<MatchItemMovementController>().setYStoppingPosition(bottomLimit + 22 * j);
                temp.GetComponent<MatchItemMovementController>()._currentState = MatchItemStates.Falling;
                temp.GetComponent<MatchItemColor>().RandomColor();
            }
        }







    }

}
