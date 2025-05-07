using UnityEngine;

public class InfluenceZoneVisibilities : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private LayerMask visibilityOn;
    [SerializeField] private LayerMask visibilityOff;

    private CanvasGroup _alpha;
    private bool _isVisible = true;

    private void Start()
    {
        _cam = Camera.main;
        _alpha = GetComponent<CanvasGroup>();
    }

    public void ToggleInfluenceZoneVisibilities()
    {
        _isVisible = !_isVisible;
        if (_isVisible)
        {
            _alpha.alpha = 1f;
            _cam.cullingMask = visibilityOn;
        }
        else
        {
            _alpha.alpha = 0.2f;
            _cam.cullingMask = visibilityOff;
        }
    }
}
