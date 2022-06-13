using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Dragable : MonoBehaviour
{
    [SerializeField]
    private Collider coll = null;

    private Vector3 startPos = new Vector3();
    private bool holded = false;

    private void Reset()
    {
        coll = coll == null ? GetComponent<Collider>() : coll;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        //transform.position = 
    }
}
