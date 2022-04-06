using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HackingMiniGameController : MonoBehaviour
{
    [Header("Grid Settings")]
    public GameObject _gridTile;
    public List<GameObject> _allGridTiles;
    public int _gridSize;
    public Transform _GridCenter;

    [Header("Timer Settings")]
    private IEnumerator _timer;
    public float _amountOfTime;

    [Header("UI Settings")]
    public TextMeshProUGUI _UITimer;
    public GameObject _resultPanel;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateBoard()
    {
        //Used to align grid on center of one transform
        float boardSize = _gridSize * 20 + (_gridSize - 1 * 2);
        float bottomLimitX = _GridCenter.localPosition.x - boardSize / 2;
        float bottomLimitY = _GridCenter.localPosition.y - boardSize / 2;

        int count = 0;
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            { 
                GameObject temp = Instantiate(_gridTile, this.transform);
                temp.transform.localPosition = new Vector3(bottomLimitX + 33 * i, bottomLimitY + 33 * j, 0);
                temp.transform.SetParent(_GridCenter);

                count++;
            }
        }


        GenerateWinningTilesComination();
    }

    private void GenerateWinningTilesComination()
    {

    }

    private void ResetBoard()
    {

    } 

    public void OnStartGamePressed()
    {
        ResetBoard();
        CreateBoard();

        if (_timer != null)
        {
            StopCoroutine(_timer);
            _timer = null;
        }

        //calulating timer base on difficulty
        _timer = CountDown(_amountOfTime);
        //starting timer
        StartCoroutine(_timer);
        //reseting values

    }

    IEnumerator CountDown(float amountOfSec)
    {
        float time = 0f;
        _UITimer.text = amountOfSec.ToString();
        while (time < amountOfSec)
        {
            time += Time.deltaTime;
            float lerpValue = time / amountOfSec;
            int temp = (int)Mathf.Lerp(amountOfSec, 0.0f, lerpValue);
            _UITimer.text = temp.ToString();
            yield return null;
        }
        yield return null;
        OpenResultPanel(false);
    }

    private void OpenResultPanel(bool result)
    {
        if (_timer != null)
        {
            StopCoroutine(_timer);
            _timer = null;
        }
        //Game result display opens
        _resultPanel.SetActive(true);
        //_canPlay = false;
        if (result)
        {
            _resultPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Win";
        }
        else
        {
            _resultPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Fail";
        }
    }


}
