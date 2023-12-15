using UnityEngine;

public class TargetHitManager : MonoBehaviour
{
    // Ȱ��ȭ�� ���� ������Ʈ
    public GameObject targetObject;

    // �� �� �¾ƾ� �ϴ���
    public int hitsRequired = 5;

    // ���� ���� Ƚ��
    private int currentHits = 0;

    // ȭ���� Ʈ���ſ� �������� �� ȣ��Ǵ� �޼���
    private void OnTriggerEnter(Collider other)
    {
        // ȭ�쿡 ���� �±� �Ǵ� ���̾ Ȯ���Ͽ� ������ Ȯ��
        if (other.CompareTag("Arrow"))
        {
            Debug.Log("SHOOT!");
            // ���� Ƚ�� ����
            currentHits++;

            // ���� Ƚ���� ��ǥ Ƚ���� �����ϸ�
            if (currentHits == hitsRequired)
            {
                // ��ǥ ������Ʈ�� Ȱ��ȭ
                if (targetObject != null)
                {
                    targetObject.SetActive(true);
                }
            }

        }
    }
}
