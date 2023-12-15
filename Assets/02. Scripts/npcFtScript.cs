using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Dialogue_FT
{
    // 여러줄을 쓸 수 있게 해준다.
    [TextArea]
    public string dialogue_ft;
}


public class npcFtScript : MonoBehaviour
{

    public AudioClip npcMeetsound;
    AudioSource aud;

    private int count = 0;

    static private String[] dialogue_ft;

    public TextMeshProUGUI npc_dialog;
    public Canvas npcSpeechBubble;

    public Light ft_light;
    public Light bow_light;

    public GameObject npc_bow;

    bool ballHover = false;


    private void Awake()
    {
        dialogue_ft = new String[100];

        dialogue_ft[0] = "용케도 날 찾아왔군.";
        dialogue_ft[1] = "난 예언가 카산드라야.\n너도 그 저택을 찾는 거지?";
        dialogue_ft[2] = "내가 잘 알고 있지.\n그 전에 운세를 보지 않겠어?";
        dialogue_ft[3] = "앞으로의 여정이\n궁금하지 않아?\n";
        dialogue_ft[4] = "저 유리구슬을 쓰다듬어봐.";
        dialogue_ft[5] = "후후... 쉽지 않겠는걸?\n다리 건너 마법사를 만나봐.";


    }



    // Start is called before the first frame update
    void Start()
    {
        npcSpeechBubble.gameObject.SetActive(false);
        this.aud = GetComponent<AudioSource>();
     //   npc_bow.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballHover&&(count==4))
        {
            count++;
            npc_dialog.text = dialogue_ft[count];
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera") // 콜라이더에 플레이어가 진입했을 때
        {
            this.aud.PlayOneShot(this.npcMeetsound, 1);
            Debug.Log("Player entered the collider!");
            ft_light.gameObject.SetActive(false);
            npcSpeechBubble.gameObject.SetActive(true);
            npc_dialog.text = dialogue_ft[count];
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
        if (count < 4) { count++; }
        npc_dialog.text = dialogue_ft[count];
    }

    public void BackDialog()
    {
        if (count > 0) { count--; }
        npc_dialog.text = dialogue_ft[count];
    }

    public void HoverBall()
    {
        if (count == 4) { ballHover = true; }
    }
}
