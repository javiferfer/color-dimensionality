using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onMouseOver : MonoBehaviour
{
    public RawImage upperImage;
    public RawImage lowerImage;

    public void OnMouseEnter()
    {
        upperImage.enabled = true;
        lowerImage.enabled = true;
    }

    public void OnMouseExit()
    {
        upperImage.enabled = false;
        lowerImage.enabled = false;
    }
}