using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacja_Kostki : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100f;
    Vector2 pirerwsza_pozycja;
    Vector2 druga_pozycja;
    Vector2 obecny_obrot;
    Vector3 poprzedniaPozycjaMyszy;
    Vector3 mouseDelta;

    public GameObject kostka;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        obrot();
        Drag();
        

    }
    void Drag()
    {
        if (Input.GetMouseButton(1))
        {
            mouseDelta = Input.mousePosition - poprzedniaPozycjaMyszy;
            mouseDelta *= 0.005f;
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else
        {
            if (transform.rotation != kostka.transform.rotation)
            {
                float krok = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, kostka.transform.rotation, krok);
            }
            poprzedniaPozycjaMyszy = Input.mousePosition;
        }
    }
    void obrot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Zapisanie pozycji po pierwszym klikniêciu myszy
            pirerwsza_pozycja = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
        }

        if (Input.GetMouseButtonUp(1))
        {
            // Zapisanie pozycji po drugim klikniêciu myszy
            druga_pozycja = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            obecny_obrot = new Vector2(druga_pozycja.x - pirerwsza_pozycja.x, druga_pozycja.y - pirerwsza_pozycja.y);
            obecny_obrot.Normalize();

            if (lewyObrot(obecny_obrot))
            {
                kostka.transform.Rotate(0, 90, 0, Space.World);
            }
            else if(prawyObrot(obecny_obrot))
            {
                kostka.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (goraprawoObrot(obecny_obrot))
            {
                kostka.transform.Rotate(0, 0, -90, Space.World);
            }
            else if (goralewoObrot(obecny_obrot))
            {
                kostka.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (dolprawoObrot(obecny_obrot))
            {
                kostka.transform.Rotate(-90, 0, 0, Space.World);
            }
            else if (dollewoObrot(obecny_obrot))
            {
                kostka.transform.Rotate(0, 0, 90, Space.World);
            }

        }

         
    }
   

    bool lewyObrot(Vector2 swipe)
    {
        return obecny_obrot.x < 0 && obecny_obrot.y > -0.5f && obecny_obrot.y < 0.5f;
    }

    bool prawyObrot(Vector2 swipe)
    {
        return obecny_obrot.x > 0 && obecny_obrot.y > -0.5f && obecny_obrot.y < 0.5f;
    }
    bool goralewoObrot(Vector2 swipe)
    {
        return obecny_obrot.y > 0 && obecny_obrot.x < 0f;
    }
    bool goraprawoObrot(Vector2 swipe)
    {
        return obecny_obrot.y > 0 && obecny_obrot.x > 0f;
    }
    bool dollewoObrot(Vector2 swipe)
    {
        return obecny_obrot.y < 0 && obecny_obrot.x < 0f;
    }
    bool dolprawoObrot(Vector2 swipe)
    {
        return obecny_obrot.y < 0 && obecny_obrot.x > 0f;
    }
}
