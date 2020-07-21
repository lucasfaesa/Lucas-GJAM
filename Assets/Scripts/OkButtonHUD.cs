using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButtonHUD : MonoBehaviour
{

    [SerializeField]
    private GameObject canvasObject;

    [SerializeField]
    private Transform itensHolder;

    [SerializeField]
    private ItemClick[] itemclickScripts;

    private void Start()
    {
        itemclickScripts = FindObjectsOfType<ItemClick>();
    }

    public void CloseCanvas()
    {
        canvasObject.SetActive(false);

        foreach(Transform child in itensHolder)
        {
            child.gameObject.SetActive(false);
        }

        foreach(ItemClick itemScript in itemclickScripts)
        {
            itemScript.lookingItem = false;
        }

        Time.timeScale = 1f;
    }
}
