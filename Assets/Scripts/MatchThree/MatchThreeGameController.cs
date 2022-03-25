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

        GameObject temp = Instantiate(_MatchThreeObject, this.transform);
        temp.transform.localPosition = new Vector3(0, 100, 0);
        temp.GetComponent<MatchItemMovementController>().setYStoppingPosition(bottomLimit);
        temp.GetComponent<MatchItemMovementController>()._currentState = MatchItemStates.Falling;



    }

}
