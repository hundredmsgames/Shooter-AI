using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform shootingPos;
    List<GameObject> bullets;
	// Use this for initialization
	void Start () {
        bullets = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.D))
        {
            RotateCharacter(-1,300);
        }
        if (Input.GetKey(KeyCode.A))
        {
            RotateCharacter(1,300);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Move(gameObject, 1, transform.up, 5);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(gameObject,-1, transform.up,5);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if(bullets!=null && bullets.Count!=0)
        {
            foreach (var bullet in bullets)
            {
                Move(bullet, 1, bullet.transform.up, 10f);
            }
        }
       
	}

    private void Fire()
    {
        GameObject go = Instantiate(bulletPrefab,shootingPos.position,Quaternion.identity);
        go.transform.rotation = gameObject.transform.rotation;
        bullets.Add(go);

        Invoke("RemoveGo", 2f);
    }

    private void RemoveGo()
    {
        GameObject go = bullets[0];
        bullets.RemoveAt(0);
        DestroyImmediate(go);
    }

    private void Move(GameObject go,int dir,Vector3 forward,float boostSpeed)
    {

        go.transform.position +=dir * forward * Time.deltaTime * boostSpeed;
    }
    

    void RotateCharacter(int dir,int boostSpeed)
    {
        
        gameObject.transform.Rotate(Vector3.forward,dir * boostSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("naptın");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("naptın");
    }
}
