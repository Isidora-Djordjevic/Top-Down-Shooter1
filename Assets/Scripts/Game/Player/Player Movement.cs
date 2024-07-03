using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Vector2 _movementInput;
        private Vector2 _smoothedMovementInput;
        private Vector2 _movementInputSmoothVelocity;

    [SerializeField]
    private float _rotationSpeed;

    //ovo polje mozemo da podesimo iz Unity Editor-a
    [SerializeField]
        private float _speed;


        private void Awake()
        {
            //nalazi komponentu rigidBody2D s naseg objekta
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    //podesavanja kretanja za fiksan vremenski period
    //koristimo Move iz Input System-a
    private void SetPlayerVelocity()
    {

        //kod da start i stop ne budu nagli 
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        //brzina kretanja
        _rigidbody.velocity = _movementInput * _speed;
    }

    //ostatak kretanja implementiran je pomocu Player Input biblioteke
    private void OnMove(InputValue inputValue)
        {
            _movementInput = inputValue.Get<Vector2>();
        }


    //metoda za upravljanje rotacijom Player objekta
    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            // Dodato 90 stepeni da bi se ispravila rotacija
            float angle = Mathf.Atan2(_smoothedMovementInput.y, _smoothedMovementInput.x) * Mathf.Rad2Deg - 90f;
            float rotation = Mathf.LerpAngle(_rigidbody.rotation, angle, _rotationSpeed * Time.deltaTime);

            _rigidbody.SetRotation(rotation);
        }
    }


}

