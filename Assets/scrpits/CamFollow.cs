using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // Kameranýn takip edeceði hedef (oyuncu)
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Hedefin önünde ve yukarýsýnda bir ofset

    void LateUpdate()
    {
        // Eðer hedef belirlenmemiþse (null) iþlem yapma
        if (target == null)
            return;

        // Hedefin pozisyonuna ofset ekleyerek kameranýn hedefi takip etmesi saðlanýr
        transform.position = target.position + offset;

        // Kamerayý hedefin yönüne doðru çevir
        transform.LookAt(target);
    }
}
