using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _playerRotationSpeed = 1000f;

    private Animator _animator;  // Component Animator du joueur
    private PlayerInputActions _playerInputActions;
    private Rigidbody _rb;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        // Old input manager
        // float directionX = Input.GetAxisRaw("Horizontal");
        // float directionZ = Input.GetAxisRaw("Vertical");

        Vector2 direction2D = _playerInputActions.Player.Move.ReadValue<Vector2>();
        
        Vector3 direction = new Vector3(direction2D.x, 0f, direction2D.y);

        // Normaliser la valeur du vecteur pour ne pas dépasser 1
        direction.Normalize();

        // Déplace le joueur dans la direction du vecteur (téléportation)
        // transform.Translate(direction * Time.deltaTime * _playerSpeed, Space.World);

        //Déplacer le joueur (vitesse) avec son rigidbody dans la direction du vecteur
        _rb.linearVelocity = direction * Time.fixedDeltaTime * _playerSpeed;

        //Appliquer une force sur le rigidbody dans la direction du vesteur
        // _rb.AddForce(direction * Time.fixedDeltaTime * _playerSpeed);
        
        //Tourner le joueur dans la direction du vecteur
        if(direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation
                , _playerRotationSpeed * Time.deltaTime);

            // Jouer l'animation de marche
           _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }
}
