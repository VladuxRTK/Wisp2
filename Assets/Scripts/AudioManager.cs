using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public List<AudioClip> laserClip;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "laserSound":
                audioSource.PlayOneShot(laserClip[Random.Range(0, laserClip.Count)]);
                break;
        }
    }
}
