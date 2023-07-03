using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu_pause : MonoBehaviour
{
    public GameObject Canvas_Menu;
    public static bool menuOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuOn)
        {
            Canvas_Menu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M))
            {
                menuOn = false;
            }
        }
        else
        {
            Canvas_Menu.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M))
            {
                menuOn = true;
            }
        }
    }
    public void ToMenu()
    {
        menuOn = false;
        SceneManager.LoadScene("menu_niveaux");
    }
    public void Cancel()
    {
        menuOn = false;
    }
}
