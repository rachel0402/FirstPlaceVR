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
    public Canvas npcSpeechBubble;

    public Light twin_light;
    public Light fortune_light;

    public GameObject npc_ft;
    
    public GameObject socket1, socket2, socket3,socket4,flag;

    private void Awake()
    {
        dialogue_twin = new String[100];
        // 처음 intro 대사
        dialogue_twin[0] = "안녕? 우리는 쌍둥이 상인 \n펠리아스와 넬레아스라고 해";
        dialogue_twin[1] = "미스테리 저택 찾고 있지?";
        dialogue_twin[2] = "나약해 보이는데\n의외로 용감하구나";
        dialogue_twin[3] = "우리는 그 저택을 아주 잘 알고 있어";
        dialogue_twin[4] = "그렇지만 순순히 보내줄 순 없지";
        dialogue_twin[5] = "우리 상점에서\n다른 물건을 3개 찾으면 알려줄게";
        dialogue_twin[6] = "왼쪽 상점의 물건을\n가져와서 테이블에 두면 돼";
        dialogue_twin[7] = "과연 다 찾을 수 있을까?";
        dialogue_twin[8] = "다 찾았으면 우리에게 깃발을 줘~";
        dialogue_twin[9] = "정답이야!\n오른쪽에 있는 점쟁이에게 가봐.\n원하는 답을 찾을 수 있을 거야";
        dialogue_twin[10] = "안타깝지만 틀렸어.\n우리는 가게 일로 바빠서 널 도울 수 없어.\n저 점쟁이한테 가 봐.";

    }

    void Start()
    {
        npcSpeechBubble.gameObject.SetActive(false);
        this.aud = GetComponent<AudioSource>();

        socket1.gameObject.SetActive(false);
        socket2.gameObject.SetActive(false);
        socket3.gameObject.SetActive(false);
        socket4.gameObject.SetActive(false);

       //npc_ft.GetComponent<Collider>().enabled = false;

    }

    void Update()
    {
        if (!flag.gameObject.activeSelf)
        {
            bool s1 = CheckItem(socket1.GetComponent<Collider>());
            bool s2=CheckItem(socket2.GetComponent<Collider>());    
            bool s3=CheckItem(socket3.GetComponent<Collider>());

            if (s1 && s2 && s3)
            {
                count = 9;
                npc_dialog.text = dialogue_twin[count];
            }
            else
            {
                count = 10;
                npc_dialog.text = dialogue_twin[count];

            }
            fortune_light.gameObject.SetActive(true);
            npc_ft.GetComponent <Collider>().enabled = true;
        }




    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera") // 콜라이더에 플레이어가 진입했을 때
        {
            this.aud.PlayOneShot(this.npcMeetsound, 1);
            Debug.Log("Player entered the collider!");
            twin_light.gameObject.SetActive(false);
            npcSpeechBubble.gameObject.SetActive(true);
            npc_dialog.text = dialogue_twin[count];
            this.GetComponent<Collider>().enabled = false;
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
        if (count == 7)
        {
          //  fortune_light.gameObject.SetActive(true);
          socket1.gameObject.SetActive(true);
            socket2.gameObject.SetActive(true); 
            socket3.gameObject.SetActive(true);
            socket4.gameObject.SetActive(true);

        }
        npc_dialog.text = dialogue_twin[count];
    }

    public void BackDialog()
    {
        if (count > 0) { count--; }
        npc_dialog.text = dialogue_twin[count];
    }

    bool CheckItem(Collider collider)
    {
        if (collider.CompareTag("Correct_twin"))
        {
            return true;
        }
        else return false;
    }



}
