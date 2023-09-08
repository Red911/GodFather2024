using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRobotScript : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioSource audioAmbianceManger;

    public AudioClip robotSpawnClip;

    public AudioClip cameraMouvement;

    public AudioClip ambianceClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        audioAmbianceManger.loop = true;
        audioAmbianceManger.clip = ambianceClip;
        audioAmbianceManger.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("son spawn joué");
            MakeSpawnSound();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("sons caméra joué");
            MakeCameraSound();
        }
    }

    public void MakeSpawnSound()
    {
        audioSource.PlayOneShot(robotSpawnClip);
    }

    public void MakeCameraSound()
    {
        audioSource.PlayOneShot(cameraMouvement);
    }

    public void MakeAlbianceSound()
    {
        //audioSource.PlayOneShot(ambianceClip);
    }
}
