using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFX
{
    ButtonClick,
    PlayerJump,
    PlayerDeath,
    PlayerHurt,
    PlayerAttack,
    EnemyDeath,
    EnemyHurt,
    CollectiblePickup,
    LevelComplete
}

[System.Serializable]
public class IDSound
{
    public SFX sfx;
    public AudioClip clip;
}

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private IDSound[] sfxSounds;

    public static AudioController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFX(SFX sfx)
    {
        foreach (IDSound sound in sfxSounds)
        {
            if (sound.sfx == sfx)
            {
                sfxSource.PlayOneShot(sound.clip);
                return;
            }
        }
    }

    [ContextMenu("Build Sounds Array")]
    private void BuildSoundsArray()
    {
        List<IDSound> soundsList = new List<IDSound>();

        foreach (SFX sfx in System.Enum.GetValues(typeof(SFX)))
        {
            IDSound sound = new IDSound();
            sound.sfx = sfx;
            soundsList.Add(sound);
        }

        sfxSounds = soundsList.ToArray();
    }
}
