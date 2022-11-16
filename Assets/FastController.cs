using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastController : MonoBehaviour
{
    // Start is called before the first frame update
    int moveX = 5;
    float timer = 3;
    float randomTimer = 0.8f;
    float r;
    bool getHit = false;

    void Start()
    {
        r = Random.Range(-100, 101);
    }

    // Update is called once per frame
    void Update()
    {
        if (randomTimer == 0.8f)
        {
            r = Random.Range(-100, 101);
            while (r == 0)
            {
                r = Random.Range(-100, 101);
            }
        }
        this.transform.position -= new Vector3(r*0.001f * Time.deltaTime * 60, 0.08f * Time.deltaTime * 60, 0);
        if (this.transform.position.x <= -2.75 || this.transform.position.x >= 2.75)
        {
            r *= -1;
            this.transform.position = new Vector3((this.transform.position.x <= -2.75 ? -2.75f : 2.75f), this.transform.position.y, 0);
        }
        timer -= Time.deltaTime;
        randomTimer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        if (randomTimer < 0)
        {
            randomTimer = 0.8f;
        }
        if (this.transform.position.y < -4)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!getHit)
        {
            getHit = true;
            GameObject go = GameObject.Find("test");
            ObjController obj = (ObjController)go.GetComponent(typeof(ObjController));
            obj.GetScore(10);
        }
    }
}
