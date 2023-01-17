using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LiftLocomotor : MonoBehaviour
{
    public Animator pintu;
    public SetInteractable tombolInteractable;
    public TMP_Text indikatorLantai;
    public int lantaiTujuan;
    public int lantaiSaatIni;
    public float tinggiLantai, movingTime;
    public float elapsedTime;
    public Vector3 progressLift;


    float tinggiPlayer = 0;
    public Transform player;

    public bool gantiLantai = false;
    private void Start()
    {
        progressLift = transform.position;
        lantaiSaatIni = 1;
        lantaiTujuan = 1;
        tinggiPlayer = player.position.y;
        indikatorLantai.text = lantaiSaatIni.ToString();
        gantiLantai = false;
    }
    public void GantiLantai(int tujuan)
    {
        lantaiTujuan = tujuan;
        progressLift = transform.position;
        elapsedTime = -1f;
        gantiLantai = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gantiLantai)
        {
            if (lantaiSaatIni != lantaiTujuan)
            {
                progressLift.y = Mathf.Lerp((lantaiSaatIni - 1) * tinggiLantai, (lantaiTujuan - 1) * tinggiLantai, elapsedTime / movingTime);
                transform.position = progressLift;
                player.position = new Vector3(player.position.x, progressLift.y + tinggiPlayer, player.position.z);
                elapsedTime += Time.deltaTime;
                indikatorLantai.text = "" + (Mathf.RoundToInt(progressLift.y / tinggiLantai) + 1);
                if (elapsedTime >= movingTime)
                {
                    lantaiSaatIni = lantaiTujuan;
                    pintu.Play("buka");
                    tombolInteractable.Interactable(false);
                    gantiLantai = false;
                }
            }
            else
            {
                lantaiSaatIni = lantaiTujuan;
                pintu.Play("buka");
                tombolInteractable.Interactable(false);
                gantiLantai = false;
            }
        }
        
    }
}
