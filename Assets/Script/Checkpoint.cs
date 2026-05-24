using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SOSave soSave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soSave.currentCheckPoint = transform.position;
        }
    }
}
