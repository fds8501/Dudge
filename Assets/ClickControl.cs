using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour
{
    public GameObject gameManager;
    int layerMask = 1 << 6;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            Vector3 cameraPos = Camera.main.transform.position;
            Debug.Log($"clicked, raycast draw from {touchPos} to {cameraPos}");

            Physics.Raycast(cameraPos, (touchPos - cameraPos).normalized, out RaycastHit hit);


            if (hit.collider != null)
            {
                hit.collider.gameObject.TryGetComponent(out Button buttonComponent);
                Debug.Log("raycast attempt");
                buttonComponent.OnClickedAction();
            }
        }
    }
}
