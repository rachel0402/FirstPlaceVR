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
    public Canvas npcSpeechBubble;

    public Light twin_light;
    public Light fortune_light;

    public GameObject npc_ft;
    
    public GameObject socket1, socket2, socket3,socket4,flag;

    private void Awake()
    {
        dialogue_twin = new String[100];
        // ó�� intro ���
        dialogue_twin[0] = "�ȳ�? �츮�� �ֵ��� ���� \n�縮�ƽ��� �ڷ��ƽ���� ��";
        dialogue_twin[1] = "�̽��׸� ���� ã�� ����?";
        dialogue_twin[2] = "������ ���̴µ�\n�ǿܷ� �밨�ϱ���";
        dialogue_twin[3] = "�츮�� �� ������ ���� �� �˰� �־�";
        dialogue_twin[4] = "�׷����� ������ ������ �� ����";
        dialogue_twin[5] = "�츮 ��������\n�ٸ� ������ 3�� ã���� �˷��ٰ�";
        dialogue_twin[6] = "���� ������ ������\n�����ͼ� ���̺� �θ� ��";
        dialogue_twin[7] = "���� �� ã�� �� ������?";
        dialogue_twin[8] = "�� ã������ �츮���� ����� ��~";
        dialogue_twin[9] = "�����̾�!\n�����ʿ� �ִ� �����̿��� ����.\n���ϴ� ���� ã�� �� ���� �ž�";
        dialogue_twin[10] = "��Ÿ������ Ʋ�Ⱦ�.\n�츮�� ���� �Ϸ� �ٺ��� �� ���� �� ����.\n�� ���������� �� ��.";

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

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera") // �ݶ��̴��� �÷��̾ �������� ��
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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera")// �ݶ��̴����� �÷��̾ ������ ��
        {
            Debug.Log("Player exited the collider!"); // ����� �޽��� �߰�
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
