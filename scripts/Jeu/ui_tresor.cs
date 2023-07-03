using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ui_tresor : MonoBehaviour
{
    public GameObject tresor_1;
    public GameObject tresor_2;
    public GameObject tresor_3;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    string name_lvl;
    int nbt_lvl;
    // Start is called before the first frame update
    void Start()
    {
        name_lvl = SceneManager.GetActiveScene().name;
        string[] str_lvl = name_lvl.Split("lvl");
        nbt_lvl = int.Parse(str_lvl[1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (player_movement.nbt_tresor == 0)
        {
            tresor_1.GetComponent<RawImage>().color = Color.white;
            tresor_2.GetComponent<RawImage>().color = Color.white;
            tresor_3.GetComponent<RawImage>().color = Color.white;
        }
        if (player_movement.nbt_tresor == 1)
        {
            tresor_1.GetComponent<RawImage>().color = Color.blue;
            tresor_2.GetComponent<RawImage>().color = Color.white;
            tresor_3.GetComponent<RawImage>().color = Color.white;
        }
        if (player_movement.nbt_tresor == 2)
        {
            tresor_1.GetComponent<RawImage>().color = Color.blue;
            tresor_2.GetComponent<RawImage>().color = Color.blue;
            tresor_3.GetComponent<RawImage>().color = Color.white;
        }
        if (player_movement.nbt_tresor == 3)
        {
            tresor_1.GetComponent<RawImage>().color = Color.blue;
            tresor_2.GetComponent<RawImage>().color = Color.blue;
            tresor_3.GetComponent<RawImage>().color = Color.blue;

            if (PlayerPrefs.HasKey("record")){
                if (nbt_lvl > PlayerPrefs.GetInt("record"))
                {
                    PlayerPrefs.SetInt("record", nbt_lvl);
                    PlayerPrefs.SetInt("need_save_to_data_base", 1);
                }
            }
            else
            {
                PlayerPrefs.SetInt("record", nbt_lvl);
                PlayerPrefs.SetInt("need_save_to_data_base", 1);
            }

            StartCoroutine(Fin());
        }
        if (player_movement.pv == 0)
        {
            c1.GetComponent<RawImage>().color = Color.black;
            c2.GetComponent<RawImage>().color = Color.black;
            c3.GetComponent<RawImage>().color = Color.black;
        }
        if (player_movement.pv == 1)
        {
            c1.GetComponent<RawImage>().color = Color.red;
            c2.GetComponent<RawImage>().color = Color.black;
            c3.GetComponent<RawImage>().color = Color.black;
        }
        if (player_movement.pv == 2)
        {
            c1.GetComponent<RawImage>().color = Color.red;
            c2.GetComponent<RawImage>().color = Color.red;
            c3.GetComponent<RawImage>().color = Color.black;
        }
        if (player_movement.pv == 3)
        {
            c1.GetComponent<RawImage>().color = Color.red;
            c2.GetComponent<RawImage>().color = Color.red;
            c3.GetComponent<RawImage>().color = Color.red;
        }

    }
    IEnumerator Fin()
    {
        yield return null;
        SceneManager.LoadScene("menu_niveaux");
    }
}
