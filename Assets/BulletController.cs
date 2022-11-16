using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position+=new Vector3(0, 0.2f* Time.deltaTime*60, 0);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.y > 4)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("hit");
        if (collision.transform.tag == "target"|| collision.transform.tag == "friend")
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}
