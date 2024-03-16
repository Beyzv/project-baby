using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silinicek : MonoBehaviour
{
    public float speed = 5f; // Hareket hýzý
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bileþenini al
    }

    void FixedUpdate()
    {
        // Yatay (X ve Z eksenleri) ve dikey (Y eksen) giriþleri al
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Hareket vektörünü oluþtur
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Rigidbody'ye kuvvet uygula (velocity kullanarak deðil, AddForce kullanarak)
        rb.AddForce(movement * speed);
    }

}
