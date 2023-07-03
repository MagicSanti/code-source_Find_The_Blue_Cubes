using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBTMonstersByDifficulté : MonoBehaviour
{
    public int difficulté;                  
    // Start is called before the first frame update
    void Awake()
    {
        difficulté = PlayerPrefs.GetInt("Difficulté");
        starting();
    }
    void starting()
    {
        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Enemy");
        int nbtMonstersActive = 0;
        switch (difficulté)
        {
            case 0:
                nbtMonstersActive =0;
                break;
            case 1:
                if (Monsters.Length > 3) { nbtMonstersActive = Monsters.Length-3;}
                else { nbtMonstersActive = Monsters.Length; }
                break;
            case 2:
                if (Monsters.Length > 2) { nbtMonstersActive = Monsters.Length - 2; }
                else { nbtMonstersActive = Monsters.Length; }
                break;
            case 3:
                nbtMonstersActive = Monsters.Length;
                break;
            case 4:
                nbtMonstersActive = Monsters.Length;
                break;

        }
        foreach (GameObject monster in Monsters)
        {
            monster.SetActive(false);
            switch (difficulté)
            {
                case 0:
                    nbtMonstersActive = 0;
                    break;
                case 1:
                    nbtMonstersActive = Monsters.Length;
                    monster.GetComponent<EnemyControl>().enemyData.speed = 1.5f;
                    break;
                case 2:
                    nbtMonstersActive = Monsters.Length;
                    monster.GetComponent<EnemyControl>().enemyData.speed = 3f;
                    break;
                case 3:
                    nbtMonstersActive = Monsters.Length;
                    monster.GetComponent<EnemyControl>().enemyData.speed = 4.5f;
                    break;
                case 4:
                    nbtMonstersActive = Monsters.Length;
                    monster.GetComponent<EnemyControl>().enemyData.speed = 6f;
                    break;

            }
        }
        for (int i = 0; i <= nbtMonstersActive-1; i++)
        {
            Monsters[i].SetActive(true);
        }
    }
}
