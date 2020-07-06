using System.Collections;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;
using System.Linq;


public class BallController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public int count;
    public GameObject sphere;
    public string String;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, movevertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        Text name;
        if (other.gameObject.CompareTag("spawner"))
        {

            String = Regex.Match(other.gameObject.name, @"\d+").Value;
            sphere = GameObject.Find("Sphere" + Int32.Parse(String));
            name = GameObject.Find("Sphere" + Int32.Parse(String) + "/Canvas/Text").GetComponent<Text>();
           
             var r = new string(name.text.Reverse().ToArray());
             var o = new string(name.text.ToArray());
            
            if (r == o)
            {
                other.gameObject.SetActive(false);
                sphere.gameObject.SetActive(false);
               
            }
           
        }
    }
}