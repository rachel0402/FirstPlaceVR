using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class Dialogue_Bow
{
    // 여러줄을 쓸 수 있게 해준다.
    [TextArea]
    public string dialogue_bow;
}



public class npcBowScript : MonoBehaviour
{
    public AudioClip npcMeetsound;
    AudioSource aud;


    private int count = 0;

    static private String[] dialogue_bow;

    public TextMeshProUGUI npc_dialog;
    public Canvas npcSpeechBubble;

    public Light bow_light;
    public int arrowNum = 0;

    private void Awake()
    {
        dialogue_bow = new string[100];
        dialogue_bow[0] = "전설 속 그 저택을 찾고 있다지...?";
        dialogue_bow[1] = "여기까지 온 것을 보아\n운이 좋은 사람이구려...";
        dialogue_bow[2] = "자네 활은 잘 쏘나...?";
        dialogue_bow[3] = "그렇다면 이 자리에서\n솜씨 한 번 보여주게...";
        dialogue_bow[4] ="5발만 맞혀주게...";
    }

    // Start is called before the first frame update
    void Start()
    {
       npcSpeechBubble.gameObject.SetActive(false);
        this.aud=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera") // 콜라이더에 플레이어가 진입했을 때
        {
            this.aud.PlayOneShot(this.npcMeetsound, 1);
            Debug.Log("Player entered the collider!");
            bow_light.gameObject.SetActive(false);
            npcSpeechBubble.gameObject.SetActive(true);
            npc_dialog.text = dialogue_bow[count];
            this.GetComponent<Collider>().enabled = false;
        }
    }

    public void NextDialog()
    {
        if (count < 4) { count++; }
        npc_dialog.text = dialogue_bow[count];
    }

    public void BackDialog()
    {
        if (count > 0) { count--; }
        npc_dialog.text = dialogue_bow[count];
    }
    public void ArrowNum_Time()
    {
     arrowNum=  ((int)Time.time) % 10;
    }

}
