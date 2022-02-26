using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum PinState
 {
    Stopped,
    Up,
    Reset,
    SetInPlace
 }
public class PinController : MonoBehaviour
{
    public float _speed; 
    public bool _canStop;
    private Vector3 _direction;
    public PinState _currentState;
    public Vector3 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _direction = Vector3.up;
        _currentState = PinState.Stopped;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case PinState.Stopped:
                transform.position = _startPos;
                break;
            case PinState.Up:
                setPinDirection(Vector3.up);
                movement();
                break;
            case PinState.Reset:
                setPinDirection(Vector3.down);
                movement();
                break;
            case PinState.SetInPlace:
                
                break;
            default:
                break;
        }   
    }
    private void movement()
    {
        transform.position += _direction * _speed * Time.deltaTime; 
    }
    public void setPinDirection(Vector3 dir)
    {
        _direction = dir;
    }

    public void setPinSpeed(float speed)
    {
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DirectionChangeZone"))
        {
            _canStop = false;
            if (_currentState == PinState.Reset)
            {
                _currentState = 0;
                return;
            }
            _currentState++;
        }
        if (collision.CompareTag("CanStop"))
        {
            if(_currentState == PinState.Up)
            {
                _canStop = true;
                collision.GetComponent<AudioSource>().Play();
            }
        }

        Debug.Log("Hit");
    }

   
}
