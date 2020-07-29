using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioName, AudioClip> audioClips = new Dictionary<AudioName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized;  }
    }

    public static void Initialize(AudioSource source)
    {
        initialized = true;

        audioSource = source;

        audioClips.Add(AudioName.ButtonClick, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioName.BallHit, Resources.Load<AudioClip>("BallHit"));
        audioClips.Add(AudioName.Freeze, Resources.Load<AudioClip>("Freeze"));
        audioClips.Add(AudioName.Speed, Resources.Load<AudioClip>("Speed"));
        audioClips.Add(AudioName.Bonus, Resources.Load<AudioClip>("Bonus"));
    }

    public static void Play(AudioName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
