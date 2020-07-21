using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMan : MonoBehaviour
{

    [SerializeField]
    private LoadScene sceneManager;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private GameObject audioSourceMusic;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<LoadScene>();
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        audioSourceMusic = GameObject.Find("Music Normal");

        Destroy(audioSourceMusic);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            audioSource.Play();
            sceneManager.GoToSceneAssync("Cena Game");
            Destroy(this.gameObject);
        }
    }
}
