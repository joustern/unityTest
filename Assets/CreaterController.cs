using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterController : MonoBehaviour
{
    public static int startWay;
    enum TargetType
    {
        slow,
        fast,
        friend
    }
    public GameObject target;
    public GameObject fast_target;
    public GameObject slow_target;
    public GameObject friend_target;
    [Header("生成頻率")]
    float frc=0.4f;
    [Header("下一波時間")]
    public float next=6;
    float orgNext;
    int start = 0;
    TargetType e;
    int amount;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = frc;
        orgNext = next;
        NextPeriod();
        //CreateOption();
        //timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (ObjController.gStart)
        {
            if (start < amount)
            {
                if (timer >= frc)
                {
                    CreateOption(e);
                    //Instantiate(target, new Vector2(0, 1.5f), Quaternion.identity);
                    timer = 0;
                    start += 1;
                }
            }
            else
            {
                timer = frc;
                next -= Time.deltaTime;
                if (next <= 0)
                {
                    NextPeriod();
                    next = orgNext;
                }
            }
        }
    }
    void CreateOption(TargetType e)
    {
        switch (e)
        {
            case TargetType.fast:
                float x = Random.Range(-300, 301)*0.01f;
                Instantiate(fast_target, new Vector2(x, 4), Quaternion.identity);
                break;
            case TargetType.slow:
                Instantiate(slow_target, new Vector2(0, 4), Quaternion.identity);
                break;
            case TargetType.friend:
                Instantiate(friend_target, new Vector2(0, 4), Quaternion.identity);
                break;
        }
    }
    void NextPeriod()
    {
        start = 0;
        e = (TargetType)Random.Range(0, 3);
        //e = TargetType.fast;
        switch (e)
        {
            case TargetType.fast:
                next = 3;
                frc = 0.4f;
                amount = 10;
                break;
            case TargetType.slow:
                next = 15;
                frc = 0.8f;
                startWay = Random.Range(0, 2);
                amount = 20;
                break;
            case TargetType.friend:
                next = 6;
                frc = 0.4f;
                amount = 1;
                break;
        }
    }
}
