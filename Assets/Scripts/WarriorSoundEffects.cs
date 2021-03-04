using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSoundEffects : MonoBehaviour
{
    // Config
    [SerializeField] AudioClip[] attackSounds;
    [SerializeField] AudioClip[] deathSounds;

    public void PlayAttackSound()
    {
        AudioClip clip = attackSounds[Random.Range(0, attackSounds.Length)];
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    public void PlayDeathSound()
    {
        AudioClip clip = deathSounds[Random.Range(0, attackSounds.Length)];
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
