using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    private bool _fireContinuosly;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShoots;

    private bool _fireSingle;

    private float _lastFireTime;

    void Update()
    {
        if (_fireContinuosly || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShoots)
            {
                FireBullet();

                _lastFireTime = Time.time;
                _fireSingle = false;
            }
            
        }


    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinuosly = inputValue.isPressed;
        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }

    }

    private void FireBullet()
    {
        GameObject bullet= Instantiate(_bulletPrefab,_gunOffset.position,transform.rotation);
        Rigidbody2D rigidbody= bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = _bulletSpeed * transform.up;
    }

}
