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
    public GameObject noticeCube;
    public Canvas npcSpeechBubble;


    public GameObject npc_twin;


    public Light twin_light;
    public Light guide_light;



    private void Awake()
    {
        dialogue = new String[100];
        // 처음 intro 대사
        dialogue[0] = "반갑습니다.";
        dialogue[1] = "text1";
        dialogue[2] = "text2";
        dialogue[3] = "text3";
        dialogue[4] = "text4";
        dialogue[5] = "text5";
        dialogue[6] = "text6";
        dialogue[7] = "text7";
        dialogue[8] = "일단 뒤에 있는 쌍둥이 상인부터 만나보세요!";

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
            noticeCube.SetActive(false);
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
        if (count > 0) { count--; }
         npc_dialog.text = dialogue[count];
    }

    

}
