using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Czytanie_Kostki : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tGora;
    public Transform tDol;
    public Transform tPrzod;
    public Transform tTyl;
    public Transform tLewo;
    public Transform tPrawo;

    private List<GameObject> frontRays = new List<GameObject>();
    private List<GameObject> backRays = new List<GameObject>();
    private List<GameObject> upRays = new List<GameObject>();
    private List<GameObject> downRays = new List<GameObject>();
    private List<GameObject> leftRays = new List<GameObject>();
    private List<GameObject> rightRays = new List<GameObject>();


    private int layerMask = 1 << 8; // "8" wybór ósmego layeru nazwanego Faces


    Stan_Kostki stankostki;
    Mapa_Kostki mapaKostki;
    public GameObject emptyGO;
    void Start()
    {
        UstawRayTransform();

        stankostki = FindObjectOfType<Stan_Kostki>();
        mapaKostki = FindObjectOfType<Mapa_Kostki>();
        CzytajStan();
        Stan_Kostki.po_starcie = true;

    }




    // Update is called once per frame
    void Update()
    {
        
    }

   public void CzytajStan()
    {
        stankostki = FindObjectOfType<Stan_Kostki>();
        mapaKostki = FindObjectOfType<Mapa_Kostki>();

        stankostki.Gora = Czytaj(upRays, tGora);
        stankostki.Dol = Czytaj(downRays, tDol);
        stankostki.Przod = Czytaj(frontRays, tPrzod);
        stankostki.Tyl = Czytaj(backRays, tTyl);
        stankostki.Lewo = Czytaj(leftRays, tLewo);
        stankostki.Prawo = Czytaj(rightRays, tPrawo);

        mapaKostki.Ustaw();
    }

   public void UstawRayTransform()
    {
        upRays = BuildRays(tGora, new Vector3(90, 90, 0));
        downRays = BuildRays(tDol, new Vector3(270, 90, 0));
        frontRays = BuildRays(tPrzod, new Vector3(0, 90, 0));
        backRays = BuildRays(tTyl, new Vector3(0, 270, 0));
        leftRays = BuildRays(tLewo, new Vector3(0, 180, 0));
        rightRays = BuildRays(tPrawo, new Vector3(0, 0, 0));
    }


   public List<GameObject>BuildRays(Transform raytransform, Vector3 kierunek)
    {
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();
        
        // Stowrzenie 9 ray'i 
        // |0|1|2|
        // |3|4|5|
        // |6|7|8|

        for (int i = 1; i > -2; i--)
        {
            for (int j = -1; j < 2; j++)
            {
                Vector3 startPos = new Vector3(raytransform.localPosition.x + j, raytransform.localPosition.y + i, raytransform.localPosition.z);
                GameObject rayStart = Instantiate(emptyGO, startPos, Quaternion.identity, raytransform);
                rayStart.name = rayCount.ToString();
                rays.Add(rayStart);
                rayCount++;
            }
        }
        raytransform.localRotation = Quaternion.Euler(kierunek);
        return rays;
    }

    public List<GameObject> Czytaj(List<GameObject> rayStarts, Transform rayTransform)
    {
        List<GameObject> facesHit = new List<GameObject>();

        foreach(GameObject rayStart in rayStarts)
        {
            Vector3 ray = rayStart.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                facesHit.Add(hit.collider.gameObject);
                print(hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }
       

       

        return facesHit;
        
    }
}
