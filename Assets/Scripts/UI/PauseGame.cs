using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
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

    public void SetEffectsVolume(float volume)
    {
        AudioManager am = FindObjectOfType<AudioManager>();
        am.SetVolume("BlopSound", volume);
        am.SetVolume("BubbleRow", volume);
        am.SetVolume("BubbleCollision", volume);
        am.SetVolume("ClusterDestroyed", volume);
    }

    public void SetMusicVolume(float volume)
    {
        FindObjectOfType<AudioManager>().SetVolume("Theme", volume);
    }

}
