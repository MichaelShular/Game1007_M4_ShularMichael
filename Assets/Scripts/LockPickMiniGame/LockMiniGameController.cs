using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMiniGameController : MonoBehaviour
{
    public GameObject _pinSet;
    public GameObject _startPosition;
    public Vector3 _pitSetSpacing;
    public List<GameObject> _allPinInGame;
    public GameObject _pick;
    public float _pickHeight;
    public int currentPinPickIsOn;
    // Start is called before the first frame update
    void Start()
    {
        currentPinPickIsOn = 0;
        createLock(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentPinPickIsOn > 0)
        {
            currentPinPickIsOn--;
            _pick.transform.position = new Vector3(_allPinInGame[currentPinPickIsOn].transform.position.x, _pickHeight, _allPinInGame[currentPinPickIsOn].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && currentPinPickIsOn < _allPinInGame.Count- 1)
        {
            currentPinPickIsOn++;
            _pick.transform.position = new Vector3(_allPinInGame[currentPinPickIsOn].transform.position.x, _pickHeight, _allPinInGame[currentPinPickIsOn].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && _allPinInGame[currentPinPickIsOn].GetComponentInChildren<PinController>()._currentState == PinState.Stopped)
        {
            _allPinInGame[currentPinPickIsOn].GetComponentInChildren<PinController>()._currentState = PinState.Up;
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
        _pick = Instantiate(_pick, transform);
        _pick.transform.position = new Vector3(_allPinInGame[currentPinPickIsOn].transform.position.x, _pickHeight, _allPinInGame[currentPinPickIsOn].transform.position.z);
    }



}
