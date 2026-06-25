using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.AudioSystem
{
    [CreateAssetMenu(fileName = "newAudioData", menuName = "ScriptableObject/AudioData")]
    public class SOAudioData : ScriptableObject
    {
        public List<AudioClip> BGMList = new List<AudioClip>();
        public List<AudioClip> SEList = new List<AudioClip>();
    }
}
