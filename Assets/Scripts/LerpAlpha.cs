using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LerpAlpha : MonoBehaviour
{
    [SerializeField]
    private Text textToLerp;

    [SerializeField]
    private Image imageToLerp;

    [SerializeField]
    private Text obgJogar;

    [SerializeField]
    private Text nameToLerp;


    private float time = 0;

    private float time2 = 0;

    [SerializeField]
    private float speed = 0.1f;

    [SerializeField]
    private bool resetTime = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;

        if(textToLerp != null)
        {
            textToLerp.color = new Color(textToLerp.color.r, textToLerp.color.g, textToLerp.color.b, Mathf.Lerp(0, 1, time));
            nameToLerp.color = new Color(nameToLerp.color.r, nameToLerp.color.g, nameToLerp.color.b, Mathf.Lerp(0, 1, time));
        }

        if(textToLerp != null && nameToLerp.color.a >= 1)
        {
            time2 += Time.deltaTime * speed;

            textToLerp.color = new Color(textToLerp.color.r, textToLerp.color.g, textToLerp.color.b, Mathf.Lerp(1, 0, time2*6));
            nameToLerp.color = new Color(nameToLerp.color.r, nameToLerp.color.g, nameToLerp.color.b, Mathf.Lerp(1, 0, time2*6));

            obgJogar.color = new Color(obgJogar.color.r, obgJogar.color.g, obgJogar.color.b, Mathf.Lerp(0, 1, time2/1.3f));

            if (obgJogar.color.a >= 1f)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if(imageToLerp != null)
        {
            imageToLerp.color = new Color(imageToLerp.color.r, imageToLerp.color.g, imageToLerp.color.b, Mathf.Lerp(1, 0, time));
        }
    }
}
