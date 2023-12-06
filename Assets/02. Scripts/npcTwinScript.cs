using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[System.Serializable]
public class Dialogue_Twin
{
    // 여러줄을 쓸 수 있게 해준다.
    [TextArea]
    public string dialogue_twin;
}


public class npcTwinScript : MonoBehaviour
{
    public AudioClip npcMeetsound;
    AudioSource aud;

    static public int npc_talk_int = 0;
    private int count = 0;
    static private String[] dialogue_twin;

    public TextMeshProUGUI npc_dialog;
    public GameObject noticeCube;
    public Canvas npcSpeechBubble;

    public Light twin_light;
    public Light fortune_light;

    private void Awake()
    {
        dialogue_twin = new String[100];
        // 처음 intro 대사
        dialogue_twin[0] = "안녕? 우리는 쌍둥이 상인 어쩌구 저쩌구라고 해";
        dialogue_twin[1] = "text1";
        dialogue_twin[2] = "text2";
        dialogue_twin[3] = "text3";
        dialogue_twin[4] = "text4";
        dialogue_twin[5] = "text5";
        dialogue_twin[6] = "text6";
        dialogue_twin[7] = "text7";
        dialogue_twin[8] = "우리 상점에서 다른 물품을 3개 찾으면 얌전히 보내주도록 하지!";

    }

    void Start()
    {
        npcSpeechBubble.gameObject.SetActive(false);
        this.aud = GetComponent<AudioSource>();

    }

    void Update()
    {





    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera") // 콜라이더에 플레이어가 진입했을 때
        {
            this.aud.PlayOneShot(this.npcMeetsound, 1);
            Debug.Log("Player entered the collider!");
            noticeCube.SetActive(false);
            twin_light.gameObject.SetActive(false);
            npcSpeechBubble.gameObject.SetActive(true);
            npc_dialog.text = dialogue_twin[count];
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
        if (count == 8)
        {
          //  fortune_light.gameObject.SetActive(true);
        }
        npc_dialog.text = dialogue_twin[count];
    }

    public void BackDialog()
    {
        if (count > 0) { count--; }
        npc_dialog.text = dialogue_twin[count];
    }



}
