using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu_principal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jouer()
    {
        SceneManager.LoadScene("menu_niveaux");
    }
    public void info_aide()
    {
        SceneManager.LoadScene("info_aide");
    }

}
