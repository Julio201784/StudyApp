﻿/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {

    public GameObject[] choices = new GameObject[3];
    public Vector2 anchored;

    public void OnDrop(PointerEventData eventData) {
        //Debug.Log("OnDrop");
        
    }

}
