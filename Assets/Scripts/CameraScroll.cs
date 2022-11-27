using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public GameObject staminaBar;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.Instance.transform.position + new Vector3(0,0,-15);
    }
    public void DebuffVision() {
        GetComponent<Camera>().orthographicSize *= 0.85f;
        staminaBar.GetComponent<RectTransform>().SetPositionAndRotation(Player.Instance.transform.position + new Vector3(0, Player.Instance.transform.lossyScale.y + .85f, 0), Quaternion.identity);
    }
}
