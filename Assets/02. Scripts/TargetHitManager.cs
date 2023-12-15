using UnityEngine;

public class TargetHitManager : MonoBehaviour
{
    // 활성화할 게임 오브젝트
    public GameObject targetObject;

    // 몇 번 맞아야 하는지
    public int hitsRequired = 5;

    // 현재 맞은 횟수
    private int currentHits = 0;

    // 화살이 트리거에 진입했을 때 호출되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        // 화살에 대한 태그 또는 레이어를 확인하여 맞은지 확인
        if (other.CompareTag("Arrow"))
        {
            Debug.Log("SHOOT!");
            // 맞은 횟수 증가
            currentHits++;

            // 맞은 횟수가 목표 횟수에 도달하면
            if (currentHits == hitsRequired)
            {
                // 목표 오브젝트를 활성화
                if (targetObject != null)
                {
                    targetObject.SetActive(true);
                }
            }

        }
    }
}
