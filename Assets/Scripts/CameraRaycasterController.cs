using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRaycasterController : MonoBehaviour {

    [SerializeField]
    BoolValue selectingEnabled;

    private Physics2DRaycaster raycaster;


    private void Start() {
        raycaster = GetComponent<Physics2DRaycaster>();
        selectingEnabled.OnValueChanged += ManageRaycaster;
    }


    private void ManageRaycaster(bool enable) {
        raycaster.enabled = enable;
    }

    private void OnDestroy() {
        selectingEnabled.OnValueChanged -= ManageRaycaster;
    }
}
