using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleEventsController : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnToggleTrue;
    [SerializeField] private UnityEvent _ONToggleFalse;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        _toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged();
        });
    }

    private void ToggleValueChanged()
    {
        if (_toggle.isOn)
            _OnToggleTrue?.Invoke();
        else
            _ONToggleFalse?.Invoke();
    }

}
