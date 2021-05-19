using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class MakeAudioSource
    {

        private AudioSource audioSource;
        private float volume;
        private bool loop;
        private bool playAwake;
        private float minDistance;
        private float maxRolloffDistance;
        private float dropLevel;


        public void setPlayAwake(bool play)
        {
            playAwake = play;
        }


        public void setVolume(float amount)
        {
            volume = amount;
        }


        public void setLoop(bool isLoop)
        {
            loop = isLoop;
        }


        public void setMinDistance(float min)
        {
            minDistance = min;
        }


        public void setMaxRolloffDistance(float max)
        {
            maxRolloffDistance = max;
        }


        public void setDropLevel(float drop)
        {
            dropLevel = drop;
        }


        public AudioSource setupAudioSource(AudioClip audioClip, GameObject gameObject)
        {
            audioSource = gameObject.AddComponent<AudioSource>();

            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.loop = loop;
            audioSource.playOnAwake = playAwake;

            // start the clip from a random point
            audioSource.minDistance = minDistance;
            audioSource.maxDistance = maxRolloffDistance;
            audioSource.dopplerLevel = dropLevel;

            return audioSource;
        }


        public void playAudio()
        {
            audioSource.Play();
        }
    }
}