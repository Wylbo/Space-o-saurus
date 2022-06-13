using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DragTarget : MonoBehaviour
{

    [SerializeField]
    private Collider coll = null;
    [field: SerializeField]
    public DragData DragDataTarget { get; protected set; } = new DragData();

    public bool Placed { get; protected set; } = false;

    private void Reset()
    {
        coll = coll == null ? GetComponent<Collider>() : coll;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In");
        Dragable dragable = other.GetComponent<Dragable>();
        if (dragable.DragData.color == DragDataTarget.color && dragable.DragData.shape == DragDataTarget.shape)
        {
            Placed = true;
            dragable.PlaceToCenter(transform.position, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out");
        Dragable dragable = other.GetComponent<Dragable>();
        if (dragable.DragData.color == DragDataTarget.color && dragable.DragData.shape == DragDataTarget.shape)
        {
            Placed = true;
            dragable.PlaceToCenter(transform.position, false);
            ;
        }
    }
}
