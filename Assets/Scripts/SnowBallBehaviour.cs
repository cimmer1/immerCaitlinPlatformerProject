using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallBehaviour : MonoBehaviour
{
    public float DieTime;
    public float Damage;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(DieTime);
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
