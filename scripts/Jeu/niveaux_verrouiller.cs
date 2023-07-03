using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class niveaux_verrouiller : MonoBehaviour
{

    [Header("UI\n")]
    public GameObject[] lvl_btn;
    public static GameObject[] btn_lvl;
    [Header("Autres Variables\n")]

    int record;
    string path;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("need_save_to_data_base") && PlayerPrefs.GetInt("need_save_to_data_base") == 1)
        {
            SaveToJson();
        }
        else
        {

            LoadFromJson();

        }

    }
    public void Load()
    {
        btn_lvl = lvl_btn;

        if (!PlayerPrefs.HasKey("record"))
        {
            PlayerPrefs.SetInt("record", 0);
        }

        for (int i = 0; i < btn_lvl.Length; i++)
        {
            btn_lvl[i].GetComponent<Button>().interactable = false;

            if (i == 0)
            {
                btn_lvl[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                if (PlayerPrefs.GetInt("record") > i - 1)
                {
                    btn_lvl[i].GetComponent<Button>().interactable = true;
                }       
            }
            


        }
    }
    public void SaveToJson()
    {
        PlayerStats playerStats = new();
        playerStats.record = PlayerPrefs.GetInt("record");
        string json = JsonUtility.ToJson(playerStats);

        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            path = Application.persistentDataPath + "/stats.json";

            File.WriteAllText(path, json);
        }

        Load();

        Debug.Log("Sauvegarde terminée");

    }
    
    public void LoadFromJson()
    {
        PlayerStats playerStats = new();

        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            path = Application.persistentDataPath + "/stats.json";


            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                playerStats = JsonUtility.FromJson<PlayerStats>(json);
                PlayerPrefs.SetInt("record", playerStats.record);
            }
        }

        Load();
        Debug.Log("Chargement terminée");
    }
    public class PlayerStats
    {
        public int record;
    }

}
