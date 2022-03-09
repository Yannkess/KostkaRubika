using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    // Start is called before the first frame update

    private List<GameObject> aktywnaStrona;
    private Vector3 localForward;
    private Vector3 mouseRef;
    private bool dragging = false;
    private float sensitivity = 0.4f;
    private Vector3 rotacja;
    private float speed = 400f;

    private bool autmatycznaRotacja = false;

    private Quaternion targetQuaterion;

    private Czytanie_Kostki czytajKostke;
    private Stan_Kostki stanKostki;
    void Start()
    {
        czytajKostke = FindObjectOfType<Czytanie_Kostki>();
        stanKostki = FindObjectOfType<Stan_Kostki>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            ObrocStrone(aktywnaStrona);
            if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
                ObrocPoprawnie();
            }
        }

        if (autmatycznaRotacja)
        {
            AutomatycznaRotacja();
        }
    }

    public void Obroc(List<GameObject> strona)
    {
        aktywnaStrona = strona;
        mouseRef = Input.mousePosition;
        dragging = true;

        localForward = Vector3.zero - strona[4].transform.parent.transform.localPosition;
    }

    public void StartAutoRotacji(List<GameObject> strona, float kat)
    {
        stanKostki.Wybierz(strona);
        Vector3 localForward = Vector3.zero - strona[4].transform.parent.transform.localPosition;
        targetQuaterion = Quaternion.AngleAxis((int)kat, localForward) * transform.localRotation;
       

        aktywnaStrona = strona;
        autmatycznaRotacja = true;
    }


    private void ObrocStrone(List<GameObject> strona)
    {
        rotacja = Vector3.zero;

        Vector3 mouseOffset = (Input.mousePosition - mouseRef);

        if (strona == stanKostki.Przod)
        {
            rotacja.x = (mouseOffset.x - mouseOffset.y) * sensitivity * -1;
        }
        if (strona == stanKostki.Tyl)
        {
            rotacja.x = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
        }

        if (strona == stanKostki.Gora)
        {
            rotacja.y = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;
        }
        if (strona == stanKostki.Dol)
        {
            rotacja.y = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
        }
        if (strona == stanKostki.Lewo)
        {
            rotacja.z = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;
        }
        if (strona == stanKostki.Prawo)
        {
            rotacja.z = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
        }
        //obroc

        transform.Rotate(rotacja, Space.Self);

        mouseRef = Input.mousePosition;
    }

    public void ObrocPoprawnie()
    {
        Vector3 vec = transform.localEulerAngles;

        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;

        targetQuaterion.eulerAngles = vec;
        transform.localEulerAngles = vec;
        autmatycznaRotacja = true;
    }

    private void AutomatycznaRotacja()
    {
        dragging = false;
        var step = speed * Time.deltaTime;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaterion, step);

        if(Quaternion.Angle(transform.localRotation,targetQuaterion) <= 1)
        {
            stanKostki.Odloz(aktywnaStrona, transform.parent);
            czytajKostke.CzytajStan();
            Stan_Kostki.automatycznaRotacja = false;
            autmatycznaRotacja = false;
            dragging = false;
        }
    }
}
