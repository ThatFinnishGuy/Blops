using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void OnEnable()
    {
        Pause();
    }

    void OnDisable()
    {
        Resume();
    }

    void Resume()
    {
        Time.timeScale = 1f;
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }

}
