using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseRumah : MonoBehaviour
{
    public TextAsset dataRaw;
    public List<Sprite> gambar;
    public List<AudioClip> audio;
    public bool generate;
    public List<DataProvinsi> Data;
    private void OnValidate()
    {
        if (generate)
        {
            generateData();
            generate = false;
        }
    }

    void generateData()
    {
        string dataOlah = dataRaw.text;
        for (int i = 0; i <= 10; i++)
        {
            string nomer = i + ". ";
            dataOlah = dataOlah.Replace(nomer, "|");
        }
        dataOlah = dataOlah.Replace("1|", "|").Replace("2|", "|").Replace("3|", "|");
        Debug.Log(dataOlah);
        string[] dataPecah = dataOlah.Split('|');
        if (Data==null)
        {
            Data = new List<DataProvinsi>();
        }
        else
        {
            Data.Clear();
        }
        char[] spliter = {'\n'};
        for (int i = 1; i < dataPecah.Length; i++)
        {
            string[] spliterData = dataPecah[i].Split(spliter, 2);
            string[] header = spliterData[0].Split(':');
            Data.Add(new DataProvinsi(header[0].Replace("Rumah adat", "").Replace("Rumah Adat", "").Trim(), header[1].Trim(), spliterData[1].Trim(), gambar[i - 1]));
        }
    }
}
[System.Serializable]
public class DataProvinsi
{
    public string provinsi, nama;
    [TextArea]
    public string deskripsi;
    public Sprite gambar;
    public Sprite[] animasi;

    public DataProvinsi(string provinsi, string nama, string deskripsi)
    {
        this.provinsi = provinsi;
        this.nama = nama;
        this.deskripsi = deskripsi;
    }

    public DataProvinsi(string provinsi, string nama, string deskripsi, Sprite gambar)
    {
        this.provinsi = provinsi;
        this.nama = nama;
        this.deskripsi = deskripsi;
        this.gambar = gambar;
    }
}