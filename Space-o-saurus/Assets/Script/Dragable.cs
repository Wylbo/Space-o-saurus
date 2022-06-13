using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Dragable : MonoBehaviour
{

    [SerializeField]
    private Collider coll = null;
    [SerializeField]
    private bool returnToBasePoint;
    [SerializeField]
    private float speedToReturn;
    [SerializeField]
    private DragData dragData;
    public DragData DragData => dragData;

    public event UnityAction<Dragable> On_Placed;

    public UnityEvent OnPlaced;

    public bool Placed { get; protected set; } = false;

    private Vector3 startPos = new Vector3();
    private float distance;
    private bool dragging;
    private Transform newPos;

    private bool draggable = true;

    private void Reset()
    {
        coll = coll == null ? GetComponent<Collider>() : coll;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDown()
    {
        if (!draggable)
            return;

        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
        if (Placed)
        {
            transform.parent = newPos;
            transform.position = newPos.position;
            OnPlaced?.Invoke();
            On_Placed?.Invoke(this);
        }
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = startPos.z;
            transform.position = rayPoint;

        }
        else
        {
            if (!Placed && returnToBasePoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speedToReturn * Time.deltaTime);
            }
        }
    }

    public void PlaceToCenter(Transform point, bool placed)
    {
        newPos = point;
        Placed = placed;
    }

}
