using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LockMiniGameController : MonoBehaviour
{
    public GameObject _pinSet;
    public GameObject _startPosition;
    public Vector3 _pitSetSpacing;
    public List<GameObject> _allPinInGame;
    public GameObject _pick;
    public GameObject _gamePick;
    public float _pickHeight;
    public int _currentPinPickIsOn;
    public GameObject _resultPanel;
    private IEnumerator _timer;
    public float _amountOfTime;

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
        yield return new WaitForSeconds(amountOfSec);
        openCanvas(false);
    }
}
