using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 3;
    bool getHit = false;
    /*public Sprite sp2;
    public SpriteRenderer spriteRenderer;(2)*/
    void Start()
    {
        /*//change sprite texture
        Texture2D tx2 = (Texture2D)Resources.Load("target1");
        sp2 = Sprite.Create(tx2, new Rect(0, 0, tx2.width, tx2.height), new Vector2(0.5f,0.5f));
        this.GetComponent<SpriteRenderer>().sprite = sp2;(1)*/

        /*spriteRenderer = this.GetComponent<SpriteRenderer>();//change sprite texture in unity
        spriteRenderer.sprite = sp2;(2)*/
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0, 0.06f * Time.deltaTime * 60, 0);
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
        //print("hit");
        //Destroy(collision.gameObject);
        if (!getHit)
        {
            getHit = true;
            GameObject go = GameObject.Find("test");
            ObjController obj = (ObjController)go.GetComponent(typeof(ObjController));
            obj.GetScore(-2);
        }
    }
}
