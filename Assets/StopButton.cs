using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : Button
{

    public override void OnClickedAction()
    {
        foreach (GameObject target in TimeRoutine.instance.MainUIGroup)
        {
            target.SetActive(false);
        }

        foreach (GameObject target in TimeRoutine.instance.standingbyUIGroup)
        {
            target.SetActive(true);
        }

        TimeRoutine.instance.StopTimeCoroutine();
    }
}
