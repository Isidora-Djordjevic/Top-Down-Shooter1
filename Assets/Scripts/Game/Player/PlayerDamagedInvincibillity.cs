using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibillity : MonoBehaviour
{

    [SerializeField]
    private float _invincibilityDuration;
    private InvincibillityController _invincibilityController;

    [SerializeField]
    private Color _flashColor;

    [SerializeField]
    private int _numberOfFlashes;

    private void Awake()
    {
            _invincibilityController= GetComponent<InvincibillityController>();

    }

    public void StartInvincibility()
    {

        _invincibilityController.StartInvincibillity(_invincibilityDuration,_flashColor,_numberOfFlashes);



    }
}
