using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{


    public class CrouchSoundMaker : MonoBehaviour
    {
        [SerializeField] private AudioSource source = null;

        [SerializeField] private float soundRange = 25f;

        [SerializeField] private Sound.SoundType soundType = Sound.SoundType.Danger;

        [SerializeField] private LayerMask groundLayer;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, soundRange);
        }
        private void OnCollisionEnter(Collision collision)
        {   

                // Check if the collided object is on the ground layer
                if (((1 << collision.gameObject.layer) & groundLayer) == 0)
                    return;

                PlaySound();
            
        }

        private void PlaySound()
        {
            if (source.isPlaying) // If already playing a sound, don't allow overlapping sounds
                return;

            source.Play();
            var sound = new Sound(transform.position, soundRange, soundType);
            Sounds.MakeSound(sound);
        }
    }
}

