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
    // �������� �� �� �ְ� ���ش�.
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

        dialogue_ft[0] = "���ɵ� �� ã�ƿԱ�.";
        dialogue_ft[1] = "�� ���� ī�����.\n�ʵ� �� ������ ã�� ����?";
        dialogue_ft[2] = "���� �� �˰� ����.\n�� ���� ��� ���� �ʰھ�?";
        dialogue_ft[3] = "�������� ������\n�ñ����� �ʾ�?\n";
        dialogue_ft[4] = "�� ���������� ���ٵ���.";
        dialogue_ft[5] = "����... ���� �ʰڴ°�?\n�ٸ� �ǳ� �����縦 ������.";


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

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera") // �ݶ��̴��� �÷��̾ �������� ��
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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera")// �ݶ��̴����� �÷��̾ ������ ��
        {
            Debug.Log("Player exited the collider!"); // ����� �޽��� �߰�
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
