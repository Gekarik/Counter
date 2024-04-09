using System.Collections;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _stepValue = 1;

    public event Action<bool> Clicked;

    private TextMeshProUGUI _textMeshPro;
    private Coroutine _coroutine;
    private int _counter;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _coroutine = StartCoroutine(nameof(AddValue));
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            ToggleCoroutine();
    }

    private void ToggleCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(nameof(AddValue));
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(nameof(AddValue));
        }

        Clicked?.Invoke(_coroutine == null);
    }

    private IEnumerator AddValue()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            _counter += _stepValue;
            _textMeshPro.text = _counter.ToString();
            yield return wait;
        }
    }
}
