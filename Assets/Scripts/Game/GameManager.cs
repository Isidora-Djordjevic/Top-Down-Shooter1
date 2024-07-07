using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float _timeToWaitBeforeExit;
    public void OnPlayerDied()
    {
        Invoke(nameof(EndGame), _timeToWaitBeforeExit);
    }
    private void EndGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
