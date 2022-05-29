using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonTrials : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed, buttonClicked;
    public void OnPointerDown(PointerEventData eventData){
        buttonPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData){
        buttonPressed = false;
    }	
}
