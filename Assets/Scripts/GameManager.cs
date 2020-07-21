using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Animator truckAnim, carAnim, manAnim;

    [SerializeField]
    private BoxCollider carCollider;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioSource endGameAudio;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private MouseLook mouseLookScript;

    [SerializeField]
    private Camera camPlayer;

    [SerializeField]
    private GameObject neveNormal;

    [SerializeField]
    private GameObject neveInversa;

    [SerializeField]
    private GameObject endGameCanvas;

    [SerializeField]
    private Image blinkImage;

    [SerializeField]
    private Image blackImage;

    [SerializeField]
    private float speed = 4f;

    private float time = 0; 
    private float time2 = 0;

    private bool canBlink;


    // Update is called once per frame
    void Update()
    {
        if(canBlink)
        {
            time += Time.deltaTime * speed;
            blinkImage.color = new Color(blinkImage.color.r, blinkImage.color.g, blinkImage.color.b, Mathf.Lerp(0, 1, time));
        }
        if(blinkImage.color.a >= 1f)
        {
            time2 += Time.deltaTime * speed;
      
            blinkImage.color = new Color(blinkImage.color.r, blinkImage.color.g, blinkImage.color.b, Mathf.Lerp(1, 0, time/10));
        }
    }

    public void GetBackInTime()
    {
        carCollider.enabled = false;
        endGameCanvas.SetActive(true);
        canBlink = true;
        audioSource.Pause();
        neveNormal.SetActive(false);
        neveInversa.SetActive(true);
        mouseLookScript.enabled = false;
        camPlayer.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        canvas.gameObject.SetActive(false);
        carAnim.SetBool("isTimeToReverse", true);
        truckAnim.SetBool("isTimeToReverse", true);
        manAnim.SetBool("isTimeToReverse", true);
        StartCoroutine(ChangeScenes());
        endGameAudio.Play();
    }

    private IEnumerator ChangeScenes()
    {
        yield return new WaitForSeconds(5.8f);

        blackImage.color = new Color(blackImage.color.r, blackImage.color.g, blackImage.color.b, 1);

        SceneManager.LoadScene("Cena Fim");
    }
}
