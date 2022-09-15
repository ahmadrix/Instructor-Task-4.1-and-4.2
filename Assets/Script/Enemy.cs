using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] Players;
    private Rigidbody enemyRb;
    public int count;
    public bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RandomDigit();
        

        if(check == true && Players[count] != null)
        {
            
        Vector3 lookDirection = (Players[count].transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * 5);
        
        if(Players[count].transform.position.y < -3)
        {
            check = false;
            Destroy(Players[count]);
            RandomDigit();
        }

        if(transform.position.y < -3)
        {
            Destroy(gameObject);
        }

        }
        
    }

    int RandomDigit()
    {       
        check = true;
        count =  Random.Range(0, Players.Length);
        return count;
    }

    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * 2, ForceMode.Impulse);
        }

        else if(collision.gameObject.CompareTag("MainPlayer"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * 2, ForceMode.Impulse);
        }
        
    }
}
