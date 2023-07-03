using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class player_movement : MonoBehaviour
{
    public float speed=5.0f;
    public float speed_camera = 100.0f;
    public bool invincible;
    public static int pv = 3;
    public static int nbt_tresor;
    public Text TXTInvincible;
    // Start is called before the first frame update
    void Start()
    {
        nbt_tresor = 0;
        pv = 3;
    }

    private void FixedUpdate()
    {
        if (menu_pause.menuOn==false)
        {
            float z = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime*-1;
            float r = Input.GetAxis("Horizontal") * speed_camera * Time.fixedDeltaTime;
            transform.Translate(0, 0, z);
            transform.Rotate(0, r, 0);
        }

        if (transform.position.y < -100||pv<=0)
        {
            SceneManager.LoadScene("menu_niveaux");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "tresor")
        {
            nbt_tresor++;
            Destroy(collision.gameObject);
        }
    }
    public void Protection()
    {
        StartCoroutine(IProtection());
    }
    public IEnumerator IProtection()
    {
        invincible = true;
        pv--;
        TXTInvincible.text = "INVINCIBLE";
        yield return new WaitForSeconds(5);
        invincible = false;
        TXTInvincible.text = "";
    }
}
