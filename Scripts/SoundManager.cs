using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public List<Sound> sounds;


    public void PlaySound(string soundName)
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            if (sounds[i].name == soundName)
            {
                sounds[i].Play();
            }
        }
    }
}
