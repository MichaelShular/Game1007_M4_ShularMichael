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
    public GameObject _CodeCombinationUI;
    public Transform _EasyButton;
    public Transform _MediumButton;
    public Transform _HardButton;

    private string _code;
    private string[,] _codeList;

    public List<string> _EasyCombination;
    public List<string> _MediumCombination;
    public List<string> _HardCombination;

    public bool[] _combinationSuccess;
    public int _currentHackCheck;

    public List<GameObject> _EasyCombinationUI;
    public List<GameObject> _MediumCombinationUI;
    public List<GameObject> _HardCombinationUI;

    bool firstGame;

    public PlayerStats _playerStats;


    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        if (_playerStats._HackingSkillLevel < 3)
        {
            _gridSize = 7;
        }
        else if (_playerStats._HackingSkillLevel < 6)
        {
            _gridSize = 6;
        }
        else
        {
            _gridSize = 5;
        }

        _allGridTiles = new GameObject[_gridSize, _gridSize];
        _codeList = new string[_gridSize, _gridSize];
        _combinationSuccess = new bool[3] { true, true, true };
        _currentHackCheck = -1;
        firstGame = true;

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
            string tempString = _allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code;
            _EasyCombination.Add(tempString);

            GameObject tempGameObject = Instantiate(_CodeCombinationUI);
            tempGameObject.transform.SetParent(_EasyButton);
            tempGameObject.transform.position = new Vector3(50 + i * 33, _EasyButton.position.y - 30, 0);
            tempGameObject.GetComponent<TextMeshProUGUI>().text = tempString;

            _EasyCombinationUI.Add(tempGameObject);

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
            string tempString = _allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code;
            _MediumCombination.Add(tempString);

            GameObject tempGameObject = Instantiate(_CodeCombinationUI);
            tempGameObject.transform.SetParent(_MediumButton);
            tempGameObject.transform.position = new Vector3(50 + i * 33, _MediumButton.position.y - 30, 0);
            tempGameObject.GetComponent<TextMeshProUGUI>().text = tempString;

            _MediumCombinationUI.Add(tempGameObject);

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
            string tempString = _allGridTiles[temp, temp2].GetComponent<HackingGridSlotScript>().code;
            _HardCombination.Add(tempString);

            GameObject tempGameObject = Instantiate(_CodeCombinationUI);
            tempGameObject.transform.SetParent(_HardButton);
            tempGameObject.transform.position = new Vector3(50 + i * 33, _HardButton.position.y - 30, 0);
            tempGameObject.GetComponent<TextMeshProUGUI>().text = tempString;
            _HardCombinationUI.Add(tempGameObject);

        }
    }

    private void ResetBoard()
    {
        if (_playerStats._HackingSkillLevel < 3)
        {
            _gridSize = 7;
        }
        else if(_playerStats._HackingSkillLevel < 6)
        {
            _gridSize = 6;
        }
        else
        {
            _gridSize = 5;
        }

        _allGridTiles = new GameObject[_gridSize, _gridSize];
        _codeList = new string[_gridSize, _gridSize];


        _combinationSuccess = new bool[3] { true, true, true };
        _currentHackCheck = -1;

        if (_timer != null)
        {
            StopCoroutine(_timer);
            _timer = null;
        }

        //calulating timer base on difficulty
        _timer = CountDown(_amountOfTime + (_playerStats._HackingSkillLevel * 5));
        //starting timer
        StartCoroutine(_timer);
        //reseting values

        _resultPanel.SetActive(false);



    }

    public void OnStartGamePressed()
    {
        CleanBoard();
        ResetBoard();
        CreateBoard();
        firstGame = false;
    }

    private void CleanBoard()
    {
        if (firstGame) return;
        foreach (var tile in _allGridTiles)
        {
            Destroy(tile.gameObject);
        }
        foreach (var UI in _EasyCombinationUI)
        {
            Destroy(UI.gameObject);
        }
        foreach (var UI in _MediumCombinationUI)
        {
            Destroy(UI.gameObject);
        }
        foreach (var UI in _HardCombinationUI)
        {
            Destroy(UI.gameObject);
        }
        _EasyCombinationUI.Clear();
        _MediumCombinationUI.Clear();
        _HardCombinationUI.Clear();
        _EasyCombination.Clear();
        _MediumCombination.Clear();
        _HardCombination.Clear();

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

    public void OpenResultPanel(bool result)
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
