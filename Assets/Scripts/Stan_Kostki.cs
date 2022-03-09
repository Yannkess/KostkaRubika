using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stan_Kostki : MonoBehaviour

    
{
    public List<GameObject> Przod = new List<GameObject>();
    public List<GameObject> Tyl = new List<GameObject>();
    public List<GameObject> Gora = new List<GameObject>();
    public List<GameObject> Dol = new List<GameObject>();
    public List<GameObject> Lewo = new List<GameObject>();
    public List<GameObject> Prawo = new List<GameObject>();

    public static bool automatycznaRotacja = false;
    public static bool po_starcie = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wybierz(List<GameObject> stronaKostki)
    {
        foreach (GameObject face in stronaKostki)
        {
            if (face != stronaKostki[4])
            {
                face.transform.parent.transform.parent = stronaKostki[4].transform.parent;
            } 
        }
        
        
    }

    public void Odloz(List<GameObject> littleCubes, Transform pivot)
    {
        foreach (GameObject littleCube in littleCubes)
            if(littleCube != littleCubes[4])
            {
                littleCube.transform.parent.transform.parent = pivot;
            }
    }
}
