using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Armor : MonoBehaviour
{
    [SerializeField] private float smooth;
    [SerializeField] private float distance2Destroy;

    private Rigidbody _rigidbody;
    private Collider[] _colliders;

    private UnityAction<GameObject> onAddedArmor;

    private void Start()
    {
        _colliders = GetComponents<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out PlayerArmor playerArmor))
        {
            if (playerArmor.IsAddArmor())
            {
                foreach (Collider collider in _colliders) { collider.enabled = false; }
                _rigidbody.isKinematic = true;
                onAddedArmor += playerArmor.AddArmor;
                Transform gotArmor = playerArmor.GetArmor().transform;
                StartCoroutine(AddingArmor(gotArmor));
            }
        }
    }

    private IEnumerator AddingArmor(Transform playerArmor)
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            yield return null;

            transform.position = Vector3.MoveTowards(transform.position, playerArmor.position, smooth * Time.deltaTime);

            if (Vector3.Distance(transform.position, playerArmor.position) <= distance2Destroy)
            {
                onAddedArmor?.Invoke(playerArmor.gameObject);
                onAddedArmor = null;
                Destroy(gameObject);
            }
        }
    }
}
