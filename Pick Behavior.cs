using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TrashCategory;

public class PickBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float moveSpeed = 5f;
    public TrashManager trashManager;
    public TrashSelector trashSelector; // 引用 TrashSelector
    public Transform pickupRange;

    private void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.E)) // 收集垃圾
        {
            PickupTrash();
        }
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void PickupTrash()
    {
        Collider[] hitColliders = Physics.OverlapSphere(pickupRange.position, 1f);

        foreach (var hitCollider in hitColliders)
        {
            Trash trash = hitCollider.GetComponent<TrashItem>()?.trash;

            if (trash != null && trash == trashSelector.GetSelectedTrash()) // 检查是否选择了正确的垃圾
            {
                trashManager.SpawnTrash(trash);
                Destroy(hitCollider.gameObject);
                break;
            }
        }
    }
}

internal class TrashItem
{
    internal Trash trash;
}