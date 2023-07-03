using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Choice_difficulté : MonoBehaviour
{
    public TMP_Dropdown DDifficultées;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("Difficulté"))
        {
            DDifficultées.value = PlayerPrefs.GetInt("Difficulté");
        }
        else
        {
            DDifficultées.value = 2;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Difficulté", DDifficultées.value);
    }

}
