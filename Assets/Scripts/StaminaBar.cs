using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private static StaminaBar _StaminaBar;

    public static StaminaBar Instance { get { return _StaminaBar; } }

    private Slider slider;

    private void Awake() {
        if (_StaminaBar != null && _StaminaBar != this)
        {
            Destroy(this.gameObject);
        } else {
            _StaminaBar = this;
        }
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update() {
        
    }

    public void SetStamina(float s) {
        slider.value = 0.09f+0.81f*s;
    }
}
