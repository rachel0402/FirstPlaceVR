using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -1f)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // Ư�� �±׸� ���� Collider�� �浹�ߴ��� Ȯ��
        if (other.CompareTag("Target"))
        {
            // ���� ������Ʈ�� Rigidbody ������Ʈ�� �ִ��� Ȯ��
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Rigidbody�� Kinematic���� ����
                rb.isKinematic = true;
            }
        }
    }
}
