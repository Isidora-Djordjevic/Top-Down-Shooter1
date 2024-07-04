using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour

{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCoolDown;


    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    //postavljamo pravac kretanja
    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
       
       
    }


    private void HandleRandomDirectionChange()
    {
        _changeDirectionCoolDown -= Time.deltaTime;
        if (_changeDirectionCoolDown <= 0)
        {
            float angleChange=Random.Range(-90f,+90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;
            _changeDirectionCoolDown = Random.Range(1f, 5f);
        }

    }
    private void HandlePlayerTargeting()
    {

        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }

    }

    //delta time se koristi da bi se okretao istom brzinom nezavisno od FrameRate-a
    private void RotateTowardsTarget()
    {
        

        float angle = Mathf.Atan2(_targetDirection.y, _targetDirection.x) * Mathf.Rad2Deg - 90f;
        float rotation = Mathf.LerpAngle(_rigidbody.rotation, angle, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }


    private void SetVelocity()
    {
      
        
            _rigidbody.velocity = transform.up * _speed;
        
    }
}
