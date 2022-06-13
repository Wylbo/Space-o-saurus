using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragableManager : MonoBehaviour
{
    [SerializeField]
    private List<Dragable> Dragables;
    [SerializeField]
    private Spaceship spaceship;

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
        d.On_Placed -= D_On_Placed;
        if (placed == Dragables.Count)
        {
            AllPlaced();
        }
    }

    private void AllPlaced()
    {
        spaceship.Lauch();   
    }
}
