using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu_niveaux : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToMenu()
    {
        SceneManager.LoadScene("menu_principal");
    }
    public void lvl(string id)
    {
        SceneManager.LoadScene("lvl"+id);
    }
}
