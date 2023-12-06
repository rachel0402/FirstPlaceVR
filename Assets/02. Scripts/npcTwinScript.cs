using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[System.Serializable]
public class Dialogue_Twin
{
    // �������� �� �� �ְ� ���ش�.
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
        // ó�� intro ���
        dialogue_twin[0] = "�ȳ�? �츮�� �ֵ��� ���� ��¼�� ��¼����� ��";
        dialogue_twin[1] = "text1";
        dialogue_twin[2] = "text2";
        dialogue_twin[3] = "text3";
        dialogue_twin[4] = "text4";
        dialogue_twin[5] = "text5";
        dialogue_twin[6] = "text6";
        dialogue_twin[7] = "text7";
        dialogue_twin[8] = "�츮 �������� �ٸ� ��ǰ�� 3�� ã���� ������ �����ֵ��� ����!";

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

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera") // �ݶ��̴��� �÷��̾ �������� ��
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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera")// �ݶ��̴����� �÷��̾ ������ ��
        {
            Debug.Log("Player exited the collider!"); // ����� �޽��� �߰�
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
