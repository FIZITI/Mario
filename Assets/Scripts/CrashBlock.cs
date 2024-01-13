using UnityEngine;

public class CrashBlock : MonoBehaviour
{
    [SerializeField] private GameObject _effectAfterCrash;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CrashBlock"))
        {
            Instantiate(_effectAfterCrash, collision.gameObject.transform.position + new Vector3(0f, 0f, -5f), transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}