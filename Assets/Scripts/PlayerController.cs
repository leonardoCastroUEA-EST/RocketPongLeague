using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    public bool IsPlayerOne;
    private bool _isPressingUp;
    private bool _isPressingDown;
    
    //[SerializeField] private float _maxSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (IsPlayerOne)
        {
            _isPressingUp = Input.GetKey(KeyCode.W);
            _isPressingDown = Input.GetKey(KeyCode.S);
        }
        else
        {
            _isPressingUp = Input.GetKey(KeyCode.UpArrow);
            _isPressingDown = Input.GetKey(KeyCode.DownArrow);
        }

        if (_isPressingUp)
        {
            transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime);
        }
        if (_isPressingDown)
        {
            transform.Translate(Vector2.down * _playerSpeed * Time.deltaTime);
        }
    }
}
