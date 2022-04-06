using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HackingMiniGameController : MonoBehaviour
{
    public GameObject gridTile;
    public List<GameObject> allGridTiles;

    [Header("Timer Settings")]
    private IEnumerator _timer;
    public float _amountOfTime;

    [Header("UI  Settings")]
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
