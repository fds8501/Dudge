using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : Button
{

    public override void OnClickedAction()
    {
        foreach (GameObject target in TimeRoutine.instance.MainUIGroup)
        {
            target.SetActive(true);
        }

        foreach (GameObject target in TimeRoutine.instance.standingbyUIGroup)
        {
            target.SetActive(false);
        }

        TimeRoutine.instance.StartTimeCoroutine();
    }
}
