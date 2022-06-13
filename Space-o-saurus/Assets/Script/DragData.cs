using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DragData 
{
    [SerializeField]
    public Shape shape;
    [SerializeField]
    public ShapeColor color;
}

public enum Shape
{
    Square,
    circle,
    triangle
}

public enum ShapeColor
{
    Red,
    Blue,
    Yellow
}
