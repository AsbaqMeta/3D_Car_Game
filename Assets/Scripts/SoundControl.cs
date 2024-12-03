using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Sound Control", menuName ="SoundControl")]
public class SoundControl : ScriptableObject
{
    public AudioSource[] GameSound;
}
