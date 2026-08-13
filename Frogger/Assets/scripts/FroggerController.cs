using UnityEngine;

public class FroggerController : MonoBehaviour
{
    public HandSignReceiver signReceiver;
    public float gridSize = 1f;
    public float moveCooldown = 0.2f;

    private float _lastMoveTime = -999f;

    private void Reset()
    {
        signReceiver = FindObjectOfType<HandSignReceiver>();
    }

    private void OnEnable()
    {
        if (signReceiver != null)
            signReceiver.OnSignChanged += HandleSignChanged;
    }

    private void OnDisable()
    {
        if (signReceiver != null)
            signReceiver.OnSignChanged -= HandleSignChanged;
    }

    private void HandleSignChanged(string sign, float confidence)
    {
        if (Time.time - _lastMoveTime < moveCooldown) return;

        Vector3 delta = SignToDirection(sign);
        if (delta == Vector3.zero) return;

        transform.position += delta * gridSize;
        _lastMoveTime = Time.time;
        Debug.Log($"[FroggerController] Moved via sign '{sign}' (confidence {confidence:F2})");
    }

    private Vector3 SignToDirection(string sign)
    {
        switch (sign)
        {
            case "tiger":    return Vector3.forward;
            case "boar":  return Vector3.back;
            case "ox":     return Vector3.left;
            case "rat":    return Vector3.right;
            default:       return Vector3.zero;
        }
    }
}
