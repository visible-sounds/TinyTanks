using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class BulletBasic : MonoBehaviour
{
    private Vector3 shootDir;
    private float decay;
    [SerializeField] private float moveSpeed = 1f;

    public void Setup(Vector3 _shootDir, Vector3 _position, float _decay, float moveSpeed)
    {
        shootDir = _shootDir;
        decay = _decay;
        transform.position = _position;
        transform.eulerAngles = shootDir;
        this.enabled = true;

        // Decay
        Decay();
    }

    private void FixedUpdate()
    {
        transform.position += (transform.forward * moveSpeed * Time.deltaTime);
    }

    private async void Decay()
    {
        await Task.Delay((int)decay * 1000); // Convert seconds to miliseconds await to destroy.
        Addressables.Release(this.gameObject);
    }
}
