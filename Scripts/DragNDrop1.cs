// for testing pourposes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDropPage : MonoBehaviour, IDropHandler
{

    public GameObject[] choices = new GameObject[3];

    bool[] choicesb = new bool[3];
    void Start()
    {
        int order = Random.Range(0, 100);
        order %= 3;

        switch (order)
        {
            case 0:
                choicesb[0] = true;
                break;
            case 1:
                choicesb[1] = true;
                break;
            case 2:
                choicesb[2] = true;
                break;
            default:

                break;
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (choices[0].GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 0))
            {
                if (choicesb[0])
                {
                    Debug.Log("Correct!");
                }
                else
                {
                    Debug.Log("Wrong!");
                }
            }
            else if (choices[1].GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 0))
            {
                if (choicesb[1])
                {
                    Debug.Log("Correct!");
                }
                else
                {
                    Debug.Log("Wrong!");
                }
            }
            else if (choices[2].GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 0))
            {
                if (choicesb[2])
                {
                    Debug.Log("Correct!");
                }
                else
                {
                    Debug.Log("Wrong!");
                }
            }


        }
    }

}
