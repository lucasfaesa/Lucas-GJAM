using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReceiver : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.UnPause();
        audioSource.volume = 1f;
    }
}
