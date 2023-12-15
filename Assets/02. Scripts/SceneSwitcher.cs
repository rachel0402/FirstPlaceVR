using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // 전환할 씬의 이름
    public string targetSceneName = "Room3";

    // 플레이어가 진입하는 영역을 나타내는 Collider
    private void OnTriggerEnter(Collider other)
    {
        // 만약 플레이어가 진입하면
        if (other.CompareTag("Player"))
        {
            // 지정된 씬으로 전환
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
