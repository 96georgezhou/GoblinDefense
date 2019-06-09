using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IDropHandler
{
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped");
//        throw new System.NotImplementedException();
    }
}