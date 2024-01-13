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
        transform.Rotate(0, 0, Random.Range(20, 340) * _rotationSpeed * Time.deltaTime);
    }
}