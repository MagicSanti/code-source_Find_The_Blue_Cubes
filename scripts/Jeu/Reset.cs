using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class Reset : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        string path = Application.persistentDataPath + "/stats.json";


        if (File.Exists(path))
        {
            File.Delete(path);
        }
        SceneManager.LoadScene("menu_principal");
    }
}
