using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HackingMiniGameController : MonoBehaviour
{
    [Header("Grid Settings")]
    public GameObject _gridTile;
    public GameObject[,] _allGridTiles;
    public int _gridSize;
    public Transform _GridCenter;

    [Header("Timer Settings")]
    private IEnumerator _timer;
    public float _amountOfTime;

    [Header("UI Settings")]
    public TextMeshProUGUI _UITimer;
    public GameObject _resultPanel;


    private string _code;
    private string[,] _codeList;

    public List<string> _EasyCombination;
    public List<string> _MediumCombination;
    public List<string> _HardCombination;



    // Start is called before the first frame update
    void Start()
    {
        _allGridTiles = new GameObject[_gridSize, _gridSize];
        _codeList = new string[_gridSize, _gridSize];
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

                _allGridTiles[i, j] = temp;

                CreateCode();
                temp.GetComponentInChildren<TextMeshProUGUI>().text = _code;
                _codeList[i, j] = _code;

                temp.GetComponent<HackingGridSlotScript>().row = j;
                temp.GetComponent<HackingGridSlotScript>().column = i;
                temp.GetComponent<HackingGridSlotScript>().code = _code;

                count++;
            }
        }


        GenerateWinningTilescCombination();
    }

    private void GenerateWinningTilescCombination()
    {

        int temp = Random.Range(0, _gridSize);
        int temp2 = Random.Range(0, _gridSize);
        int checkNum;
        for (int i = 0; i < 2; i++)
        {
            if (i % 2 == 0)
            {
                checkNum = temp;
                while (checkNum == temp2)
                {
                    temp = Random.Range(0, _gridSize);
                }
            }
            else
            {
                checkNum = temp2;
                while (checkNum == temp2)
                {
                    temp2 = Random.Range(0, _gridSize);
                }
            }
            _EasyCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);
        }

        for (int i = 0; i < 3; i++)
        {
            if (i % 2 == 0)
            {
                checkNum = temp;
                while (checkNum == temp)
                {
                    temp = Random.Range(0, _gridSize);
                }
            }
            else
            {
                checkNum = temp2;
                while (checkNum == temp2)
                {
                    temp2 = Random.Range(0, _gridSize);
                }
            }
            _MediumCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);
        }

        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0)
            {
                checkNum = temp;
                while (checkNum == temp)
                {
                    temp = Random.Range(0, _gridSize);
                }
            }
            else
            {
                checkNum = temp2;
                while (checkNum == temp2)
                {
                    temp2 = Random.Range(0, _gridSize);
                }
            }
            _HardCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);
        }




        //temp2 = Random.Range(0, _gridSize);
        //_EasyCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);

        //temp = Random.Range(0, _gridSize);
        //temp2 = Random.Range(0, _gridSize);

        //_MediumCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);
        //temp2 = Random.Range(0, _gridSize);
        //_MediumCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);
        //temp = Random.Range(0, _gridSize);
        //_MediumCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);

        //temp = Random.Range(0, _gridSize);
        //temp2 = Random.Range(0, _gridSize);

        //_HardCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);
        //temp2 = Random.Range(0, _gridSize);
        //_HardCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);
        //temp = Random.Range(0, _gridSize);
        //_HardCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);
        //temp2 = Random.Range(0, _gridSize);
        //_HardCombination.Add(_allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code);

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


    private void CreateCode()
    {
        int a = Random.Range(0, 9);
        int b = Random.Range(0, 9);
        _code = a.ToString() + b.ToString();
    }



}
