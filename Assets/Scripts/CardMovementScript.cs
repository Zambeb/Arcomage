using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera MainCamera;
    private Vector3 offset;
    public Transform DefaultParent;
    public bool IsDraggable;
    public GameManager GManager;
    private void Awake()
    {
        MainCamera = Camera.allCameras[0];
        GManager = FindObjectOfType<GameManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);

        DefaultParent = transform.parent;

        IsDraggable = DefaultParent.GetComponent<DropPlace>().Type == FieldType.SELF_HAND && GManager.IsPlayerTurn;

        if (!IsDraggable)
        {
            return;
        }
        
        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsDraggable)
        {
            return;
        }
        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsDraggable)
        {
            return;
        }
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
