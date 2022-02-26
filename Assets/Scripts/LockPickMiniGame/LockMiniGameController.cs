using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LockMiniGameController : MonoBehaviour
{
    [Header("Setting GameObjects")]
    public GameObject _pinSet;
    public GameObject _startPosition;
    public GameObject _resultPanel;
    public GameObject _pick;
    public TextMeshProUGUI _UITimer;
    private GameObject _gamePick;
    public List<GameObject> _allPinInGame;
    
    [Header("Game Look Settings")]
    public Vector3 _pitSetSpacing;
    public float _pickHeight;
    private int _currentPinPickIsOn;
    
    [Header("Game Settings")]
    public float _amountOfTime;
    private IEnumerator _timer;
    
    [Header("Difficulty Settings")]
    public float _easySpeed;
    public float _MediumSpeed;
    public float _HardSpeed;
    public float _minEasySpace;
    public float _maxEasySpace;
    public float _minMediumSpace;
    public float _maxMediumSpace;
    public float _minHardSpace;
    public float _maxHardSpace;
    // Start is called before the first frame update
    void Start()
    {
        _currentPinPickIsOn = 0;
        _gamePick = null;
        _timer = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.A) && _currentPinPickIsOn > 0)
        {
            _currentPinPickIsOn--;
            _gamePick.transform.position = new Vector3(_allPinInGame[_currentPinPickIsOn].transform.position.x, _pickHeight, _allPinInGame[_currentPinPickIsOn].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && _currentPinPickIsOn < _allPinInGame.Count - 1)
        {
            _currentPinPickIsOn++;
            _gamePick.transform.position = new Vector3(_allPinInGame[_currentPinPickIsOn].transform.position.x, _pickHeight, _allPinInGame[_currentPinPickIsOn].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(_allPinInGame[_currentPinPickIsOn].GetComponentInChildren<PinController>()._currentState == PinState.Stopped)
            {
                _allPinInGame[_currentPinPickIsOn].GetComponentInChildren<PinController>()._currentState = PinState.Up;
            }
            if ((_allPinInGame[_currentPinPickIsOn].GetComponentInChildren<PinController>()._canStop))
            {
                _allPinInGame[_currentPinPickIsOn].GetComponentInChildren<PinController>()._currentState = PinState.SetInPlace;
                int counter = 0;
                for (int i = 0; i < _allPinInGame.Count; i++)
                {
                    if(_allPinInGame[i].GetComponentInChildren<PinController>()._currentState == PinState.SetInPlace)
                    {
                        counter++;
                    }
                }
                if(counter == _allPinInGame.Count)
                {
                    openCanvas(true);
                }

            }
        }
    }
    public void createLock(int numberOfPins)
    {
        for (int i = 0; i < numberOfPins; i++)
        {
            var temp = Instantiate(_pinSet, transform);
            temp.transform.position = _startPosition.transform.position + (_pitSetSpacing * i);
            _allPinInGame.Add(temp);
            switch (numberOfPins)
            {
                case 3:
                    _allPinInGame[i].GetComponentInChildren<PinController>()._speed = _easySpeed;

                    break;
                case 4:
                    _allPinInGame[i].GetComponentInChildren<PinController>()._speed = _MediumSpeed;

                    break;
                case 5:
                    _allPinInGame[i].GetComponentInChildren<PinController>()._speed = _HardSpeed;

                    break;
                default:
                    Debug.Log(numberOfPins + "Lock Settings doesn't exist");
                    break;
            }
        }
        if (_gamePick == null)
        {
            _gamePick = Instantiate(_pick, transform);
            _gamePick.transform.position = new Vector3(_allPinInGame[_currentPinPickIsOn].transform.position.x, _pickHeight, _allPinInGame[_currentPinPickIsOn].transform.position.z);
        }
    }
    public void startNewPickGame(int numberOfPins)
    {
        if(_timer != null)
        {
            StopCoroutine(_timer);
            _timer = null;
        }
        _timer = CountDown(numberOfPins * _amountOfTime);
        StartCoroutine(_timer);
        _resultPanel.SetActive(false);
        for (int i = 0; i < _allPinInGame.Count; i++)
        {
            Destroy(_allPinInGame[i].gameObject);
        }
        _allPinInGame.Clear();
        createLock(numberOfPins);
    }
    public void openCanvas(bool win)
    {
        _resultPanel.SetActive(true);
        if (win)
        {
            _resultPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Win";
        }
        else
        {
            _resultPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Fail";
        }
    }
    IEnumerator CountDown(float amountOfSec)
    {
        float time = 0f;
        _UITimer.text = amountOfSec.ToString() ;
        while (time < amountOfSec)
        {
            time += Time.deltaTime;
            float lerpValue = time / amountOfSec;
            int temp = (int)Mathf.Lerp(amountOfSec, 0.0f, lerpValue);
            _UITimer.text = temp.ToString();
            yield return null;
        }
        yield return null;
        openCanvas(false);
    }
}
