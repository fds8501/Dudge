using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardButton : Button
{
    public float point;
    // Start is called before the first frame update
    public override void OnClickedAction()
    {
        base.OnClickedAction();
        TimeRoutine.instance.cycle += point;
        Debug.Log($"cycle adjusted by {point}");
        TimeRoutine.instance.textCeiling.text = "Current cycle: " + TimeRoutine.instance.cycle;
    }
}
