using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float height;
    private float width;
    private float scaleFactor;


    private RaycastHit hit;

    [SerializeField] private GameObject dropTower;
    [SerializeField] private string name;
    [SerializeField] private Image itemImage;
    [SerializeField] private string layerName;

    private Vector3 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        height = FindObjectOfType<Canvas>().GetComponent<RectTransform>().rect.height;
        width = FindObjectOfType<Canvas>().GetComponent<RectTransform>().rect.width;
        scaleFactor = 1.5f;

        //height = Screen.height;
        //width = Screen.width;


        DragSlot.instance.dragSlot = this;
        DragSlot.instance.DragSetImage(itemImage);
        DragSlot.instance.transform.position = eventData.position;
        offset = offset = gameObject.transform.position -
                          Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                              0));
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        newPosition = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        newPosition = new Vector3(newPosition.x, newPosition.y, 0);
        DragSlot.instance.transform.position = newPosition;

        if (Physics.Raycast(DragSlot.instance.transform.position, Vector3.forward, out hit, 3))
        {
            Debug.Log("collision found");
            Debug.Log(hit.transform.gameObject.name);
        }

//        Debug.Log(DragSlot.instance.transform.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Hide the ghost
        DragSlot.instance.SetColor(0);

        // Geenrate the tower
        if (StatusPanel.instance.DecreaseMoney(5))
        {
            if (dropTower != null)
            {
                Instantiate(dropTower, DragSlot.instance.transform.position, Quaternion.identity);
                //dropTower.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
                dropTower.GetComponentInChildren<SpriteRenderer>().sortingLayerName = layerName;

//                dropTower.GetComponentInChildren<TowerTracking>().damage = damage;
                dropTower.GetComponentInChildren<TowerTracking>().towerName = name;
				if (name == "wind") {
					dropTower.GetComponent<TowerTracking> ().range = 200f;
				}

                // Recalculate the path.
                if (AstarPath.instance != null)
                    AstarPath.instance.Scan();
            }
        }
    }
}