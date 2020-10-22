using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class Bubble_NameAttribute : PropertyAttribute
{
    public string Name { get; set; }

    public Bubble_NameAttribute(string name)
    {
        Name = name;
    }

    public string Describe { get; set; }
}
