using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // ��ȯ�� ���� �̸�
    public string targetSceneName = "Room3";

    // �÷��̾ �����ϴ� ������ ��Ÿ���� Collider
    private void OnTriggerEnter(Collider other)
    {
        // ���� �÷��̾ �����ϸ�
        if (other.CompareTag("Player"))
        {
            // ������ ������ ��ȯ
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
