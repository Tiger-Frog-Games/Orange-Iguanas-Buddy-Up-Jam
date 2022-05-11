using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    #region Variables

    [SerializeField] private AudioSource[] musicAudio;
    [SerializeField] private AudioSource sfxAudio;
    [SerializeField] private PlayerController playerController;

    private AudioSource currentlyPlaying;
    private AudioSource lastPlayed;

    private float depth;

    private float volumeSetting = 1f;

    #endregion


    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        currentlyPlaying = musicAudio[0];
        musicAudio[0].volume = volumeSetting;
    }

    // Update is called once per frame
    void Update()
    {
        depth = playerController.GetDepth();

        UpdateMusic(depth);

    }

    void UpdateMusic(float depth)
    {
        if (depth > -200)
        {
            ChangeTrack(musicAudio[0]);
        }

        else if (depth > -400 && depth <= -200)
        {
            ChangeTrack(musicAudio[1]);
        }

        else if (depth > -600 && depth <= -400)
        {
            ChangeTrack(musicAudio[2]);
        }

        else if (depth > -800 && depth <= -600)
        {
            ChangeTrack(musicAudio[3]);
        }

        else if (depth <= -800)
        {
            ChangeTrack(musicAudio[4]);
        }
    }


    void ChangeTrack(AudioSource track)
    {
        if (lastPlayed != track)
        {
            lastPlayed = currentlyPlaying;
            StartCoroutine(FadeAudioSource(lastPlayed, 1f, 0f));
            currentlyPlaying = track;
            StartCoroutine(FadeAudioSource(currentlyPlaying, 3f, volumeSetting));
        }
    }

    private IEnumerator FadeAudioSource(AudioSource trackAudio, float duration, float targetVolume)
    {

        float currentTime = 0;
        float start = trackAudio.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            trackAudio.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    #endregion
}
