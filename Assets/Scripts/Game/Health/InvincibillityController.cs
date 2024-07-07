using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibillityController : MonoBehaviour
{


    private HealthContoller _healthController;
    private SpriteFlash _spriteFlash;


    private void Awake()
    {
        _healthController = GetComponent<HealthContoller>();
        _spriteFlash = GetComponent<SpriteFlash>();
    }

    public void StartInvincibillity(float invincibillityDuration, Color flashColor, int numberOfFlashes)
    {

        StartCoroutine(InvincibillityCoroutine(invincibillityDuration,flashColor,numberOfFlashes));
    }

    private IEnumerator InvincibillityCoroutine(float invincibillityDuration, Color flashColor, int numberOfFlashes)
    {
        _healthController.IsInvincible = true;
        yield return _spriteFlash.FlashCoroutine(invincibillityDuration, flashColor, numberOfFlashes);
        _healthController.IsInvincible=false;
    }


}
