using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LukisanItem : MonoBehaviour
{
    public DatabaseRumah databaseRumah;
    public int index;
    [Header("Properties")]
    public TMP_Text nama;
    public TMP_Text judul;
    public TMP_Text deskripsi;
    public Image gambarTampilan;
    public GameObject animasi;
    public bool update;
    private AudioSource audio;
    bool flagAudio;
    private void Start()
    {
        audio = transform.GetChild(0).GetChild(2).GetComponent<AudioSource>();
        flagAudio = false;
        //updateGambar();
    }
    private void Update()
    {
        if (audio.gameObject.activeSelf)
        {
            if (!flagAudio)
            {
                OneAudioPlay.instance.StopOtherAudio(audio);
                flagAudio = true;
            }
        }
        else
        {
            if (flagAudio)
            {
                flagAudio = false;
            }
        }
    }
   
    private void OnValidate()
    {
        //updateGambar();
        UpdateSound();
    }
    public void updateGambar()
    {
        DataProvinsi dataProvinsi = databaseRumah.Data[index];
        nama.text = dataProvinsi.nama;
        judul.text = "Rumah adat "+dataProvinsi.provinsi+" : "+dataProvinsi.nama;
        deskripsi.text = dataProvinsi.deskripsi;
        gambarTampilan.sprite = dataProvinsi.gambar;
        foreach (Transform item in animasi.transform)
        {
            item.gameObject.SetActive(false);
        }
        if (dataProvinsi.animasi!=null)
        {
            for (int i = 0; i < dataProvinsi.animasi.Length; i++)
            {
                if (i < 3)
                {
                    Transform img = animasi.transform.GetChild(i);
                    img.GetComponent<Image>().sprite = dataProvinsi.animasi[i];
                    img.gameObject.SetActive(true);
                }
            }
        }
        
    }
    public void UpdateSound()
    {
        Transform infoTransform = transform.GetChild(0).GetChild(2);
        
        AudioSource infoAudio;
        if (!infoTransform.GetComponent<AudioSource>())
        {
            infoAudio = infoTransform.gameObject.AddComponent<AudioSource>();

        }
        else
        {
            infoAudio = infoTransform.GetComponent<AudioSource>();
        }
    }
   
}
