using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragableManager : MonoBehaviour
{
    [SerializeField]
    private List<Dragable> Dragables;

    private int placed = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Dragable d in Dragables)
        {
            d.On_Placed += D_On_Placed;
        }   
    }

    private void D_On_Placed(Dragable d)
    {
        placed++;
        if (placed == Dragables.Count - 1)
        {

        }
    }


    private void AllPlaced()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
