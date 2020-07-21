using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckGameOver : MonoBehaviour
{

    [SerializeField]
    private GameObject gameOverCanvas;

    [SerializeField]
    private GameObject mainCanvas;

    [SerializeField]
    private AudioSource radioAudioSource;

    [SerializeField]
    private AudioSource normalAudioSource;

    [SerializeField]
    private AudioSource gameOveraudioSource;

    [SerializeField]
    private Text textToLerp;

    [SerializeField]
    private Text text2ToLerp;

    [SerializeField]
    private Image imageToLerp;

    private bool gameOver;

    private float time;

    private float time2;

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            time += Time.deltaTime * 0.3f;

            textToLerp.color = new Color(textToLerp.color.r, textToLerp.color.g, textToLerp.color.b, Mathf.Lerp(0, 1, time));

            if (textToLerp.color.a >= 1f)
            {
                time2 += Time.deltaTime * 0.3f;

                text2ToLerp.color = new Color(text2ToLerp.color.r, text2ToLerp.color.g, text2ToLerp.color.b, Mathf.Lerp(0, 1, time2));
                imageToLerp.color = new Color(imageToLerp.color.r, imageToLerp.color.g, imageToLerp.color.b, Mathf.Lerp(0, 1, time2));
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                SceneManager.LoadScene("Cena Game");
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Truck"))
        {
            radioAudioSource.Pause();
            gameOveraudioSource.Play();

            Destroy(normalAudioSource.gameObject);
            gameOver = true;
            mainCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);

            Debug.Log("entrou!");
        }
    }
}
