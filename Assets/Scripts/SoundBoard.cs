using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoard : MonoBehaviour
{
    [Header("Sound clips")]
    public AudioClip kick;
    public AudioClip snare;
    public AudioClip closedHiHat;
    public AudioClip openHiHat;

    [Header("Input keys")]
    public string kickButton = "z";
    public string snareButton = "x";
    public string closedHiHatButton = "s";
    public string openHiHatButton = "a";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Det her er grumt
    void Update()
    {
        if (Input.GetKeyDown(kickButton))
        {
            SoundManager.Instance.PlaySound(kick);
            Debug.Log("kick was played");
        }
        if (Input.GetKeyDown(snareButton))
        {
            SoundManager.Instance.PlaySound(snare);
            Debug.Log("Snare was played");
        }
        if (Input.GetKeyDown(closedHiHatButton))
        {
            SoundManager.Instance.PlaySound(closedHiHat);
            Debug.Log("Closed hihat was played");
        }
        if (Input.GetKeyDown(openHiHatButton))
        {
            SoundManager.Instance.PlaySound(openHiHat);
            Debug.Log("open hihat was played");
        }

    }
}
