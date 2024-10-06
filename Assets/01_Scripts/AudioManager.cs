using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource instrumentalAS;
    public AudioSource vocalsAS;
    public AudioSource sfxAS;
    public float instrumentalVol = 0.5f;
    public float vocalsVol = 0f;
    public float sfxVol = 0.7f;
    public List<AudioClip> BGM_Instrumental = new List<AudioClip>();
    public List<AudioClip> BGM_Vocals = new List<AudioClip>();
    public List<AudioClip> SFX = new List<AudioClip>();
    float timer = 0f;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        instrumentalAS.volume = instrumentalVol;
        instrumentalAS.loop = true;
        instrumentalAS.playOnAwake = true;

        vocalsAS.volume = vocalsVol;
        vocalsAS.loop = true;
        vocalsAS.playOnAwake = true;

        sfxAS.volume = sfxVol;
        sfxAS.loop = false;
        sfxAS.playOnAwake = false;
    }

    void Start()
    {
        StartCoroutine(InitialMusic());
    }

    IEnumerator InitialMusic()
    {
        yield return new WaitForSeconds(3f);
        PlayInstrumentalAndVocals("song_instrumental", "song_vocals");
    }

    public void PlaySFX(AudioClip sound)
    {
        sfxAS.PlayOneShot(sound);
    }

    public void PlayInstrumentalAndVocals(string instrumental, string vocals)
    {
        vocalsAS.Stop();
        instrumentalAS.Stop();
        instrumentalAS.clip = BGM_Instrumental.Find(i => i.name == instrumental);        
        instrumentalAS.Play();
        if (vocals != null)
        {
            vocalsAS.clip = BGM_Vocals.Find(v => v.name == vocals);
            vocalsAS.Play();
        }
    }

    public IEnumerator IncreaseVocalsVolume(float duration)
    {
        while (timer < duration)
        {
            timer += Time.deltaTime;
            vocalsAS.volume = Mathf.Lerp(vocalsAS.volume, instrumentalAS.volume, timer / duration);
            yield return null;
        }
        timer = 0f;
        vocalsAS.volume = instrumentalAS.volume;
    }

    public void PlayPauseBGM()
    {
        if (instrumentalAS.isPlaying)
        {
            instrumentalAS.Pause();
            vocalsAS.Pause();
        }
        else
        {
            instrumentalAS.Play();
            vocalsAS.Play();
        }
    }
}
