using UnityEngine;
using System.Collections.Generic; 

public class TrapsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _trapsList = new List<GameObject>();
    [SerializeField] private float _forceIntensity = 500;
    
    [Header("Direction de chute(X,Y,Z)")]
    [SerializeField] private float _dirX = 0f;
    [SerializeField] private float _dirY = -1f;
    [SerializeField] private float _dirZ = 0f;
    
    private Vector3 _direction;
    private List<Rigidbody> _rbsList = new List<Rigidbody>();
    
    private void Start()
    {
        foreach (var trap in _trapsList)
        {
            _rbsList.Add(trap.GetComponent<Rigidbody>());
            trap.GetComponent<Rigidbody>().useGravity = false;
        }
        _direction = new Vector3(_dirX, _dirY, _dirZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach(var rb in _rbsList)
        {
            rb.useGravity = true;
            rb.AddForce(_direction * _forceIntensity);
        }
    }
}
