using UnityEngine;

public class ColorToggler : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _counter.Clicked += HandleClicked;
    }

    private void OnDisable()
    {
        _counter.Clicked -= HandleClicked;
    }

    private void HandleClicked(bool isCounterDisabled)
    {
        if(isCounterDisabled)
            _spriteRenderer.color = Color.red;
        else
            _spriteRenderer.color = Color.green;
    }
}
