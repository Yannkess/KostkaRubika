using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapa_Kostki : MonoBehaviour
{
    Stan_Kostki stanKostki;

    public Transform gora;
    public Transform dol;
    public Transform lewo;
    public Transform prawo;
    public Transform przod;
    public Transform tyl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ustaw()
    {
        stanKostki = FindObjectOfType<Stan_Kostki>();
        UpdateMap(stanKostki.Przod, przod);
        UpdateMap(stanKostki.Tyl, tyl);
        UpdateMap(stanKostki.Gora, gora);
        UpdateMap(stanKostki.Dol, dol);
        UpdateMap(stanKostki.Lewo, lewo);
        UpdateMap(stanKostki.Prawo, prawo);
    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        foreach(Transform map in side)
        {
            if (face[i].name[0] == 'P')
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }

            if (face[i].name[0] == 'T')
            {
                map.GetComponent<Image>().color = Color.red;
            }

            if (face[i].name[0] == 'G')
            {
                map.GetComponent<Image>().color = Color.yellow;
            }

            if (face[i].name[0] == 'D')
            {
                map.GetComponent<Image>().color = Color.white;
            }

            if (face[i].name[0] == 'L')
            {
                map.GetComponent<Image>().color = Color.green;
            }

            if (face[i].name[0] == 'R')
            {
                map.GetComponent<Image>().color = Color.blue;
            }
            i++;
        }
    }
}
