﻿using UnityEngine;
using System.Collections;

public enum States
{
    IDLE,
    WALKING_RIGHT,
    WALKING_LEFT,
    JUMPING_STANDING,
    JUMPING_RIGHT,
    JUMPING_LEFT,
    DEATH
}

public enum MoveType
{
    IDLE,
    ADVANCE,
    ERRATIC
}

public class PlayerMovement : MonoBehaviour {

    [Tooltip("LayerMask for collision")]
    [SerializeField] private LayerMask _layerMask;
    [Tooltip("LayerMask for Jump")]
    [SerializeField] private LayerMask _jumpLayerMask;
    [Tooltip("Movement Speed")]
    [SerializeField] private float _standardMovingSpeed = 2.5f;
    [Tooltip("Jumping Height")]
    [SerializeField] private float _jumpingHeight = 2.5f;
    [Tooltip("Levitation length")]
    [SerializeField] private float _levLength = 3f;

    private States _playerState = States.IDLE; 
    private Rigidbody2D _rigidBody;
    private float _moveSpeed;
    private bool _grounded = true;
    private bool _isFloating = false;
    private bool _walkingRight = false;
    private bool _walkingLeft = false;

    private bool _toss = false;
    public bool toss
    {
        get { return _toss; }
        set { _toss = value; }
    }

    private float _linearDrag = 7f;    
    private float _minJumpingHeight=1.8f;
    private float _maxJumpingHeight=3f;
    private float _speedMult;
    private float _levCounter = 0;

          
    public void GInitialize()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _moveSpeed = _standardMovingSpeed;
    }

    private bool isGrounded()
    {
        RaycastHit2D __hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.3f, _layerMask);
        return __hit;
    }

    public void GUpdate()
    {        
        if(Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (_isFloating && _levCounter < _levLength)
        {
            _levCounter += Time.deltaTime;
            if(_levCounter>=_levLength)
            {
                _isFloating = false;
                _rigidBody.drag = 0.5f;
            }
        }
        else if(_levCounter>0)
        {
            _levCounter -= Time.deltaTime;
        }
        if(!_toss)
        {
            if (_walkingLeft) MoveLeft();
            else if (_walkingRight) MoveRight();
        }
        else if(isGrounded())
        {
            _toss = false;
        }
    }

    private void MoveRight()
    {
        RaycastHit2D __hit = Physics2D.Raycast(transform.position, new Vector2(1f,0),0.5f, _layerMask);
        if (!__hit)
        {
            transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
            if (!_grounded) _playerState = States.JUMPING_RIGHT;
            else _playerState = States.WALKING_RIGHT;
        }
    }

    private void MoveLeft()
    {
        RaycastHit2D __hit = Physics2D.Raycast(transform.position, new Vector2(-1f, 0), 0.5f, _layerMask);
        if (!__hit)
        {
            transform.Translate(-_moveSpeed * Time.deltaTime, 0, 0);
            if (!_grounded) _playerState = States.JUMPING_LEFT;
            else _playerState = States.WALKING_LEFT;
        }
    }

    public void Jump()
    {      
        if (isGrounded())
        {
            _rigidBody.drag = 0.5f;
            _rigidBody.velocity = Vector2.zero;
            _rigidBody.AddForce(new Vector2(0, _jumpingHeight), ForceMode2D.Impulse);
            if (_playerState == States.WALKING_LEFT) _playerState = States.JUMPING_LEFT;
            else if (_playerState == States.WALKING_RIGHT) _playerState = States.JUMPING_RIGHT;
            else if (_playerState == States.IDLE) _playerState = States.JUMPING_STANDING;
        }
        else if(_levCounter<_levLength && !_isFloating)
        {
            _isFloating = true;
            _rigidBody.drag = _linearDrag;
        }
    }

    public void Stop()
    {
        _walkingLeft = _walkingRight = false;
        if (_grounded) _playerState = States.IDLE;
        else _playerState = States.JUMPING_STANDING;
    }

    public void Move(bool p_right)
    {
        _walkingRight = p_right ? true : false;
        _walkingLeft = p_right ? false : true;
    }

    public void SetJump(float p_height)
    {
        _jumpingHeight = p_height;
        if (_jumpingHeight > _maxJumpingHeight) _jumpingHeight = _maxJumpingHeight;
        else if (_jumpingHeight < _minJumpingHeight) _jumpingHeight = _minJumpingHeight;
    }

    public void SetWalkSpeed(float p_mood)
    {
        if (p_mood <= -0.8f) _moveSpeed = _standardMovingSpeed * 1.5f;
        else if (p_mood <= -0.6f) _moveSpeed = _standardMovingSpeed * 1.2f;
        else if (p_mood <= -0.4f || p_mood >= 0.4f) _moveSpeed = _standardMovingSpeed;
        else if (p_mood >= 0.2f || p_mood <= -0.2f) _moveSpeed = _standardMovingSpeed * 0.7f;
        else if (p_mood >= -0.1f && p_mood <= 0.1f) _moveSpeed = _standardMovingSpeed * 0.5f;
    }

    public Vector2 GetPosition()
    {
        return _rigidBody.position;
    }

    public States GetState()
    {
        return _playerState;
    }
}

