using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    private UnityEngine.UI.Image _healthBarForegroundImage;

    public void UpdateHealthBar(HealthContoller healthContoller)
    {
        _healthBarForegroundImage.fillAmount = healthContoller.RemainingHealthPercentage;

    }



}
