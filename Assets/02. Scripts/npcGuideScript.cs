using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[System.Serializable]
public class Dialogue_Guide
{
    // 여러줄을 쓸 수 있게 해준다.
    [TextArea]
    public string dialogue;
}


public class npcGuideScript : MonoBehaviour
{
    public AudioClip npcMeetsound;
    AudioSource aud;

    static public int npc_talk_int = 0;
    private int count = 0;
    static private String[] dialogue;

    public TextMeshProUGUI npc_dialog;
    public Canvas npcSpeechBubble;


    public GameObject npc_twin;


    public Light twin_light;
    public Light guide_light;



    private void Awake()
    {
        dialogue = new String[100];
        // 처음 intro 대사
        dialogue[0] = "반갑습니다.";
        dialogue[1] = "이 마을의 사서 미네르바라고 합니다.";
        dialogue[2] = "전설 속 미스테리 저택을\n 찾고 있다고 들었습니다.";
        dialogue[3] = "저희 마을엔 \n 그 저택을 찾는 모험가들이 \n많이 찾아옵니다.";
        dialogue[4] = "그리고 모두 \n거기서 돌아오지 못했습니다.";
        dialogue[5] = "저는 사람들을 \n위험에서 지킬 의무가 있습니다.";
        dialogue[6] = "미스테리 저택에 가기를\n간절히 원하신다면 어쩔 수 없군요.";
        dialogue[7] = "먼저 당신의 능력을\n 보고 판단하겠습니다.";
        dialogue[8] = "일단 뒤에 있는\n 쌍둥이 상인부터 만나보세요";

    }

    void Start()
    {
        npcSpeechBubble.gameObject.SetActive(false);
        this.aud = GetComponent<AudioSource>();
        npc_twin.GetComponent<Collider>().enabled = false;

    }

    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag=="Player"||other.gameObject.tag=="MainCamera") // 콜라이더에 플레이어가 진입했을 때
        {
            this.aud.PlayOneShot(this.npcMeetsound,1);
            Debug.Log("Player entered the collider!");
            guide_light.gameObject.SetActive(false);
            npcSpeechBubble.gameObject.SetActive(true);
            npc_dialog.text = dialogue[count];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera")// 콜라이더에서 플레이어가 나갔을 때
        {
            Debug.Log("Player exited the collider!"); // 디버그 메시지 추가
            npcSpeechBubble.gameObject.SetActive(false);
        }
    }

    public void NextDialog()
    {
        if (count < 8) { count++; }
        if (count == 8) { 
        twin_light.gameObject.SetActive(true);
        npc_twin.GetComponent<Collider>().enabled = true;
        }
         npc_dialog.text=dialogue[count];
    }

    public void BackDialog()
    {
        if (count > 0&&count<8) { count--; }
        npc_dialog.text = dialogue[count];
       
    }

    

}
