using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeObjects : MonoBehaviour
{
    public Button[] buttonChangeObjects;
    public GameObject[] objects;
    public int indexObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonLeftRight()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "left")
        {
            Debug.Log("left");

            objects[indexObject].SetActive(false);
            
            indexObject -=1;

            if (indexObject < 0)
            {
                indexObject = objects.Length - 1;
            }

            objects[indexObject].SetActive(true);
        }
        else
        {
            Debug.Log("right");

            objects[indexObject].SetActive(false);

            indexObject +=1;

            if (indexObject > objects.Length - 1)
            {
                indexObject = 0;
            }
            objects[indexObject].SetActive(true);
        }
    }

    public void OnTargetFound()
    {
        for (int i = 0; i < buttonChangeObjects.Length; i++)
        {
            buttonChangeObjects[i].interactable = true;
        }
    }

    public void OnTargetLoss()
    {
         for (int i = 0; i < buttonChangeObjects.Length; i++)
         {
            buttonChangeObjects[i].interactable = false;
         }
    }
}
