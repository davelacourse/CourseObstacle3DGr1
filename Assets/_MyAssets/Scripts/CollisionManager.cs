using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private Material _hitMaterial = default(Material);
    [SerializeField] private int _collisionValue = 1;

    private bool _estToucher = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_estToucher && collision.gameObject.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material = _hitMaterial;

            //Augmenter le nombre de collision
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.AddCollision(_collisionValue);

            _estToucher = true;
        }

    }
}
