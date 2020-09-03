using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

}
