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
        // 특정 태그를 가진 Collider와 충돌했는지 확인
        if (other.CompareTag("Target"))
        {
            // 게임 오브젝트에 Rigidbody 컴포넌트가 있는지 확인
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Rigidbody를 Kinematic으로 설정
                rb.isKinematic = true;
            }
        }
    }
}
