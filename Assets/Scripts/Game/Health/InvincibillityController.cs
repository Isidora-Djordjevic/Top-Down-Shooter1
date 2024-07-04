using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibillityController : MonoBehaviour
{


    private HealthContoller _healthController;


    private void Awake()
    {
        _healthController = GetComponent<HealthContoller>();
    }

    public void StartInvincibillity(float invincibillityDuration)
    {

        StartCoroutine(InvincibillityCoroutine(invincibillityDuration));
    }

    private IEnumerator InvincibillityCoroutine(float invincibillityDuration)
    {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invincibillityDuration);
        _healthController.IsInvincible=false;
    }


}
