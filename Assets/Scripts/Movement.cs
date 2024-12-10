using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _speed = 10;

    #endregion

    #region Unity lifecycle

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Vector3 currentPosition = transform.position;
        currentPosition.x += input.x * _speed * Time.deltaTime;
        currentPosition.z += input.y * _speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    #endregion
}