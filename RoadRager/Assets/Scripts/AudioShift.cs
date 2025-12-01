using UnityEngine;

public class AudioShift : MonoBehaviour
{
    float initVolume;
    void Start()
    {
        Skills.pauseGame.AddListener(Pause);
        Skills.resumeGame.AddListener(UnPause);
        initVolume = GetComponent<AudioSource>().volume;
    }

    void Pause()
    {
        GetComponent<AudioSource>().volume = 0.1f;
        GetComponent<AudioSource>().pitch = 0.5f;
    }

    void UnPause()
    {
        GetComponent<AudioSource>().volume = initVolume;
        GetComponent<AudioSource>().pitch = 1f;
    }
}
