using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silinicek : MonoBehaviour
{
    public float speed = 5f; // Hareket h�z�
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bile�enini al
    }

    void FixedUpdate()
    {
        // Yatay (X ve Z eksenleri) ve dikey (Y eksen) giri�leri al
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Hareket vekt�r�n� olu�tur
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Rigidbody'ye kuvvet uygula (velocity kullanarak de�il, AddForce kullanarak)
        rb.AddForce(movement * speed);
    }

}
