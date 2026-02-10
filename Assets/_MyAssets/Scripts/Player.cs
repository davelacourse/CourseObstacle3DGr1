using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _playerRotationSpeed = 1000f;
    
    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(directionX, 0f, directionZ);

        // Normaliser la valeur du vecteur pour ne pas dépasser 1
        direction.Normalize();

        // Déplace le joueur dans la direction du vecteur
        transform.Translate(direction * Time.deltaTime * _playerSpeed, Space.World);

        //Tourner le joueur dans la direction du vecteur
        if(direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation
                , _playerRotationSpeed * Time.deltaTime); ;
        }
    }
}
