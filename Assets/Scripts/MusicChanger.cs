using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChanger : MonoBehaviour
{

    [SerializeField]
    private AudioSource musicNormal;

    [SerializeField]
    private AudioSource musicRadio;

    [SerializeField]
    private GameObject startCanvasTexts;

    [SerializeField]
    private Image startCanvasBg;

    [SerializeField]
    private GameObject startCanvas;

    [SerializeField]
    private Animator carAnimator, truckAnimator, manAnimator;

    private bool musicChange;

    [SerializeField]
    private float speed;

    private float time = 0;

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            musicChange = true;
            startCanvasTexts.SetActive(false);
        }

        if (musicChange)
        {
            time += Time.deltaTime * speed;

            startCanvasBg.color = new Color(startCanvasBg.color.r, startCanvasBg.color.g, startCanvasBg.color.b, Mathf.Lerp(1, 0, time));
            startCanvasBg.raycastTarget = false;
            musicNormal.volume = Mathf.Lerp(1, 0, time);
            musicRadio.volume = Mathf.Lerp(0, 1, time);

            carAnimator.SetBool("gameStarted", true);
            truckAnimator.SetBool("gameStarted", true);
            manAnimator.SetBool("gameStarted", true);

            if (startCanvasBg.color.a <= 0)
            {
                startCanvas.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
}
