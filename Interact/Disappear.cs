using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour {

    public GameObject point;

    void Start()
    {
        point.SetActive(false);
    }

	public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            point.SetActive(true);
        }
    }

}
