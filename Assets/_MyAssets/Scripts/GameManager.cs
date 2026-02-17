using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _nbCollisions;

    private void Start()
    {
        _nbCollisions = 0;
    }

    public void AddCollision(int p_collision)
    {
        _nbCollisions += p_collision;
        Debug.Log("Nombre de collisions : " + _nbCollisions);
    }
}
