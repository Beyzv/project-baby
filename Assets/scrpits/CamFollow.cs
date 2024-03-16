using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // Kameran�n takip edece�i hedef (oyuncu)
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Hedefin �n�nde ve yukar�s�nda bir ofset

    void LateUpdate()
    {
        // E�er hedef belirlenmemi�se (null) i�lem yapma
        if (target == null)
            return;

        // Hedefin pozisyonuna ofset ekleyerek kameran�n hedefi takip etmesi sa�lan�r
        transform.position = target.position + offset;

        // Kameray� hedefin y�n�ne do�ru �evir
        transform.LookAt(target);
    }
}
