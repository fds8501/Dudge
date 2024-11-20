using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjButton : Button
{
    public float point;
    // Start is called before the first frame update
    public override void OnClickedAction()
    {
        base.OnClickedAction();
        TimeRoutine.instance.time += point;
        Debug.Log($"time adjusted by {point}");
    }
}
