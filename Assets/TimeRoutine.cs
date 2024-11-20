using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeRoutine : MonoBehaviour
{
    Coroutine routine;
    Coroutine dangerCoroutine;
    public static TimeRoutine instance;

    public TextMeshProUGUI textPrime;
    public TextMeshProUGUI textSub;
    public TextMeshProUGUI textCeiling;
    public List<TextMeshProUGUI> textGroup;

    public List<GameObject> MainUIGroup;
    public List<GameObject> standingbyUIGroup;

    public GameObject alertImage;
    public GameObject dudge;
    [HideInInspector]
    public float time = 0;
    public float cycle = 31.025f;

    // Start is called before the first frame update
    // Update is called once per frame
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartTimeCoroutine()
    {
        time = cycle - 0.5f;
        if (routine == null)
        {
            routine = StartCoroutine(TimeCoroutine());
        }
    }

    public void StopTimeCoroutine()
    {
        time = cycle;
        StopCoroutine(routine);
        routine = null;
    }

    IEnumerator TimeCoroutine()
    {
        while (true)
        {
            if (time <= 0.09)
            {
                OnTimeHitZero();
            }

            else if (time <= 5.59 && time >= 3 & dangerCoroutine == null )
            {
                dangerCoroutine = StartCoroutine(OnDangerZone());
            }

            else
            {
                time -= Time.deltaTime;
            }

            int round = (int)Mathf.Floor(time);
            int mod = (int)Mathf.Floor(10 * time) % 10;
            textPrime.text = round.ToString();
            textSub.text = mod.ToString();
            yield return new WaitForEndOfFrame();
        }
    }

    void OnTimeHitZero()
    {
        time = cycle;
        Debug.Log("time hit zero");
    }

    IEnumerator OnDangerZone()
    {
        Debug.Log("danger alert coroutine started");
        OnAlertStart();
        yield return new WaitForSeconds(6.5f);
        OnAlertEnd();
        StopCoroutine(dangerCoroutine);
        dangerCoroutine = null;
    }

    void OnAlertStart()
    {
        foreach (TextMeshProUGUI tmp in textGroup)
        {
            tmp.color = Color.white;
        }
        alertImage.GetComponent<AlertImage>().SetVisible();
        dudge.SetActive(true);
    }

    void OnAlertEnd()
    {
        foreach (TextMeshProUGUI tmp in textGroup)
        {
            tmp.color = Color.black;
        }
        alertImage.GetComponent<AlertImage>().ExitVisible();
        dudge.SetActive(false);
    }
}
