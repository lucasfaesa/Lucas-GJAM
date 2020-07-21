using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClick : MonoBehaviour
{

    [SerializeField]
    private GameObject canvasObject;

    [SerializeField]
    private Text itemName;

    [SerializeField]
    private Text itemDescription;

    [SerializeField]
    private string itemDescText;

    [SerializeField]
    private GameObject itemReference;

    [SerializeField]
    private GameObject pressF;

    [SerializeField]
    private Image imageFill;

    [SerializeField]
    private GameObject okButton;

    [SerializeField]
    private ItemClick[] itemclickScripts;

    [SerializeField]
    private GameManager gameManagerScript;

    private bool isTimeForF;

    public bool lookingItem;

    // Start is called before the first frame update
    void Start()
    {
        itemclickScripts = FindObjectsOfType<ItemClick>();
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeForF)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                imageFill.fillAmount += 0.02f;
                itemReference.GetComponent<RotateObjects>().speed += 45f;
                CheckFillAmount();

            }             
        }
    }

    private void OnMouseDown()
    {
        if (!lookingItem)
        {
            Debug.Log("clicked: " + this.gameObject.name);
            Time.timeScale = 0.9f;
            canvasObject.SetActive(true);

            if(this.gameObject.name == "Foto da Família")
            {
                okButton.SetActive(false);
                pressF.SetActive(true);
                imageFill.gameObject.SetActive(true);
                isTimeForF = true;
            }

            itemName.text = this.gameObject.name;
            itemDescription.text = itemDescText;

            itemReference.SetActive(true);

            foreach (ItemClick itemScript in itemclickScripts)
            {
                itemScript.lookingItem = true;
            }
        }
    }

    private void CheckFillAmount()
    {
        if(imageFill.fillAmount >= 1f)
        {
            isTimeForF = false;
            gameManagerScript.GetBackInTime();
        }
    }
}
