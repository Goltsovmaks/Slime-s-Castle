using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Threading;

public class NewTestScript
{ 
    [UnityTest]
    public IEnumerator ApplyDamageTest() //IEnumerator
    {
        var obj = new GameObject();
        var player = obj.AddComponent<scr_Player>();

        var spawn = new GameObject();
        spawn.transform.position = new Vector3(1f, 1f, 1f);

        player.spawnPosition = spawn.transform;

        player.ApplyDamage(10);

        yield return new WaitForSeconds(1f);

        Assert.AreEqual(player.maxHealth, player.currentHealth);
        Assert.AreEqual(obj.transform.position, spawn.transform.position);
    }

    [UnityTest]
    public IEnumerator DamageWhileStayingInaTrapTest()
    {
        var obj = new GameObject();
        var player = obj.AddComponent<scr_Player>();
        obj.AddComponent<BoxCollider2D>();
        obj.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
        obj.AddComponent<Rigidbody2D>().gravityScale = 0;

        var trap = new GameObject();
        trap.AddComponent<scr_Trap>();
        trap.AddComponent<BoxCollider2D>().isTrigger = true;
        trap.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
        trap.AddComponent<Rigidbody2D>().gravityScale = 0;

        var spawn = new GameObject();
        spawn.transform.position = new Vector3(100f, 100f, 100f);
        player.spawnPosition = spawn.transform;

        obj.transform.position = new Vector2(0f, 0f);
        trap.transform.position = new Vector2(0f, 0f);

        var timeUp = Time.time;
        yield return new WaitForSeconds(1f);



        obj.tag = "Player";

        //do
        //{
        //    Debug.Log("waiting...");
        //} while (Time.time < (2f+timeUp));

        Assert.AreEqual(3, player.currentHealth);

        yield return new WaitForSeconds(1f);

        //Assert.AreEqual(3, player.currentHealth);

        //Debug.Log("Time is " + Time.time);

        //yield return new WaitForSeconds(7f);



        //Debug.Log("Time is " + Time.time);

        Assert.AreEqual(player.maxHealth, player.currentHealth);


        //yield return null;

    }

    [UnityTest]
    public IEnumerator TimeTest()
    {
        float time1 = 0;
        float time2 = 0;

        float ellipson = 0.01f;

        time1 = Time.time;
        yield return new WaitForSeconds(5);
        time2 = Time.time;

        Debug.Log("Time1 is " + time1);
        Debug.Log("Time2 is " + time2);
        Debug.Log("Sub is " + (time2 - time1 - 5f));

        Assert.LessOrEqual(time2 - time1 - 5f, ellipson);
    }

}
