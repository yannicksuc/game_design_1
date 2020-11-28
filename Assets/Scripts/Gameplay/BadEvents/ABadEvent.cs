using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABadEvent : MonoBehaviour
{
    [Tooltip("-1 is Infinite")]
    public int maxNbClone = 1;
}
