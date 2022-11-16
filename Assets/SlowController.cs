using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowController : MonoBehaviour
{
    float timer = 16;
    int moveX=5;
    bool getHit = false;

    // Start is called before the first frame update
    void Start()
    {
        if (CreaterController.startWay == 0) moveX *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= -2.75 || this.transform.position.x >= 2.75)
        {
            moveX *= -1;
            this.transform.position = new Vector3((this.transform.position.x <= -2.75?-2.75f:2.75f),this.transform.position.y, 0);
        }
        this.transform.position -= new Vector3(moveX*0.01f * Time.deltaTime * 60, 0.02f * Time.deltaTime * 60, 0);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
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
            GameObject go=GameObject.Find("test");
            ObjController obj = (ObjController)go.GetComponent(typeof(ObjController));
            obj.GetScore(5);
        }
    }
}
