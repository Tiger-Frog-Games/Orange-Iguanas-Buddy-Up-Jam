using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    #region Variables

    [SerializeField] private AudioSource[] musicAudio;
    [SerializeField] private AudioSource[] sfxAudio;
    [SerializeField] private PlayerController playerController;

    private AudioSource currentlyPlaying;
    private AudioSource lastPlayed;

    private float depth;

    private float musicVolSetting = 1f;
    private float sfxVolSetting = 1f;

    #endregion


    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        currentlyPlaying = musicAudio[0];
        musicAudio[0].volume = musicVolSetting;
    }

    // Update is called once per frame
    void Update()
    {
        depth = playerController.GetDepth();

        UpdateMusic(depth);

    }

    void UpdateMusic(float depth)
    {
        if (depth > -100)
        {
            ChangeTrack(musicAudio[0]);
        }

        else if (depth > -300 && depth <= -100)
        {
            ChangeTrack(musicAudio[1]);
        }

        else if (depth > -500 && depth <= -300)
        {
            ChangeTrack(musicAudio[2]);
        }

        else if (depth > -675 && depth <= -500)
        {
            ChangeTrack(musicAudio[3]);
        }

        else if (depth <= -675)
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
            StartCoroutine(FadeAudioSource(currentlyPlaying, 3f, musicVolSetting));
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

    private void PlaySFX(AudioSource sfx)
    {
        sfx.Play();
    }    

    public void TorpedoLaunch()
    {
        PlaySFX(sfxAudio[0]);
    }

    public void TorpedoImpact()
    {
        PlaySFX(sfxAudio[1]);
    }

    public void CannonballLaunch()
    {
        PlaySFX(sfxAudio[2]);
    }
    public void CannonballImpact()
    {
        PlaySFX(sfxAudio[3]);
    }

    public void Upgrade()
    {
        PlaySFX(sfxAudio[4]);
        PlaySFX(sfxAudio[5]);
        PlaySFX(sfxAudio[4]);
        PlaySFX(sfxAudio[5]);
        PlaySFX(sfxAudio[4]);
        PlaySFX(sfxAudio[5]);
    }

    #endregion
}
