using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrokenPlatform : Platform
{
    protected override void DuckHitsPlatform(Collision2D collision)
    {
        Debug.Log("Heeeeeeeeeeeeeeeeeere");

        var list = transform.GetComponentsInChildren<Transform>().Where(child => child.name == "Part1" || child.name == "Part2").ToList();

        for (int i = 0; i < list.Count(); i++)
        {
            list[i].GetComponent<BoxCollider2D>().enabled = true;
            list[i].GetComponent<SpriteRenderer>().enabled = true;
            list[i].gameObject.AddComponent<Rigidbody2D>();
            list[i].parent = null;
            Destroy(list[i].gameObject, 2);
        }
        Destroy(gameObject);
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    Debug.Log(transform.GetChild(i).name + " что ты блять ");
        //    if (transform.GetChild(i).name == "Part1" || transform.GetChild(i).name == "Part2")
        //    {
        //        transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
        //        transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
        //        transform.GetChild(i).gameObject.AddComponent<Rigidbody2D>();
        //        Debug.Log(transform.GetChild(i).name + " paaaart ");
        //        Destroy(transform.GetChild(i).gameObject, 2);
        //    }
        //    else
        //    {
        //        Debug.Log(transform.GetChild(i).name + "ne paaaart ");

        //        Destroy(transform.GetChild(i).gameObject);
        //    }
        //    transform.GetChild(i).parent = null;
        //}
        //Destroy(gameObject);
    }
}
