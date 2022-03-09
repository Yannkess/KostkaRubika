using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wybierz : MonoBehaviour
{

    Stan_Kostki stanKostki;
    Czytanie_Kostki czytanieKostki;
    int layerMask = 1 << 8;
    // Start is called before the first frame update
    void Start()
    {
        stanKostki = FindObjectOfType<Stan_Kostki>();
        czytanieKostki = FindObjectOfType<Czytanie_Kostki>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Stan_Kostki.automatycznaRotacja)
        {
            czytanieKostki.CzytajStan();
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 100.0f, layerMask))
            {
                GameObject face = hit.collider.gameObject;

                List<List<GameObject>> stronyKostki = new List<List<GameObject>>()
                {
                    stanKostki.Gora,
                    stanKostki.Dol,
                    stanKostki.Lewo,
                    stanKostki.Prawo,
                    stanKostki.Przod,
                    stanKostki.Tyl
                };

                foreach (List<GameObject> stronaKostki in stronyKostki)
                {
                    if (stronaKostki.Contains(face))
                    {
                        stanKostki.Wybierz(stronaKostki);
                        stronaKostki[4].transform.parent.GetComponent<PivotRotation>().Obroc(stronaKostki);
                    }
                }
            }
        } 
    }
}
