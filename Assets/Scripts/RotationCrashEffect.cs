using UnityEngine;

public class RotationCrashEffect : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        Destroy(transform.parent.gameObject, 2f);
    }

    private void Update()
    {
        transform.Rotate(0, 0, 180 * _rotationSpeed * Time.deltaTime);
    }
}