using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    //public da bi druge skripte koristile
    public bool AwareOfPlayer { get; private set; }

    //da bi znalo u kom pravcu da juri player objekat
    public Vector2 DirectionToPlayer { get; private set; }

    //odredimo na kojoj distanci krece da juri player objekat
    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

    // Start is called before the first frame update
    void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    //odredimo distancu i aktiviramo pracenje ako je manja od zadate
    void Update()
    {
        //izracuna se magnitude vektora distance
        Vector2 enemyToPlayerVecor = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVecor.normalized;

        if(enemyToPlayerVecor.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
