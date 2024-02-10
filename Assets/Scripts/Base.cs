using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public Enum type;

    public bool isTargeted;

    private void Awake()
    {
        isTargeted = false;
    }
}
