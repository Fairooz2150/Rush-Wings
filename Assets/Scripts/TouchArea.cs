using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchArea : MonoBehaviour, 
IPointerDownHandler, IPointerUpHandler //unity will call the function when user touches UI

{
    public bool isTouching = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isTouching = true;
    } 
    public void OnPointerUp(PointerEventData eventData)
    {
              isTouching = false;
        
    }
}
