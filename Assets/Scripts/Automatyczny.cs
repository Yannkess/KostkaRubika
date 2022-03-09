using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatyczny : MonoBehaviour
{
    public static List<string> listaRuchow = new List<string>() {};
    private readonly List<string> wszystkieRuchy = new List<string>()
    {
        "U","D","L","R","F","B",
        "U2","D2","L2","R2","F2","B2",
        "U'","D'","L'","R'","F'","B'",
    };

    private Stan_Kostki stanKostki;
    private Czytanie_Kostki czytajKostke;


    // Start is called before the first frame update
    void Start()
    {
        stanKostki = FindObjectOfType<Stan_Kostki>();
        czytajKostke = FindObjectOfType<Czytanie_Kostki>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (listaRuchow.Count > 0 && !Stan_Kostki.automatycznaRotacja && Stan_Kostki.po_starcie) // Kostka sie nie rusza
        {
            WykonajRuch(listaRuchow[0]);
            listaRuchow.Remove(listaRuchow[0]);
        }
    }

    public void Wymieszaj()
    {
        List<string> ruchy = new List<string>();
        int dlugoscMieszania = Random.Range(10, 30);
        for (int i = 0; i < dlugoscMieszania; i++)
        {
            int randomRuch = Random.Range(0, wszystkieRuchy.Count);
            ruchy.Add(wszystkieRuchy[randomRuch]);
        }
        listaRuchow = ruchy;
    }



    void WykonajRuch(string ruch)
    {
        czytajKostke.CzytajStan();
        Stan_Kostki.automatycznaRotacja = true;
        if (ruch == "U")
        {
            ObrocStrone(stanKostki.Gora, -90);
        }
        if (ruch == "U'")
        {
            ObrocStrone(stanKostki.Gora, 90);
        }
        if (ruch == "U2")
        {
            ObrocStrone(stanKostki.Gora, -180);
        }
        if (ruch == "D")
        {
            ObrocStrone(stanKostki.Dol, -90);
        }
        if (ruch == "D'")
        {
            ObrocStrone(stanKostki.Dol, 90);
        }
        if (ruch == "D2")
        {
            ObrocStrone(stanKostki.Dol, -180);
        }
        if (ruch == "L")
        {
            ObrocStrone(stanKostki.Lewo, -90);
        }
        if (ruch == "L'")
        {
            ObrocStrone(stanKostki.Lewo, 90);
        }
        if (ruch == "L2")
        {
            ObrocStrone(stanKostki.Lewo, -180);
        }
        if (ruch == "R")
        {
            ObrocStrone(stanKostki.Prawo, -90);
        }
        if (ruch == "R'")
        {
            ObrocStrone(stanKostki.Prawo, 90);
        }
        if (ruch == "R2")
        {
            ObrocStrone(stanKostki.Prawo, -180);
        }
        if (ruch == "F")
        {
            ObrocStrone(stanKostki.Przod, -90);
        }
        if (ruch == "F'")
        {
            ObrocStrone(stanKostki.Przod, 90);
        }
        if (ruch == "F2")
        {
            ObrocStrone(stanKostki.Przod, -180);
        }
        if (ruch == "B")
        {
            ObrocStrone(stanKostki.Tyl, -90);
        }
        if (ruch == "B'")
        {
            ObrocStrone(stanKostki.Tyl, 90);
        }
        if (ruch == "B2")
        {
            ObrocStrone(stanKostki.Tyl, -180);
        }
    }
    void ObrocStrone (List<GameObject> strona, int kat)
    {
        PivotRotation pr = strona[4].transform.parent.GetComponent<PivotRotation>();
        pr.StartAutoRotacji(strona, kat);
    }
}
