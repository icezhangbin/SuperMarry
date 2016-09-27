//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ExplodeRock : MonoBehaviour
{
    public GameObject m_explodeRock;

    public bool m_isRotate = false;

    private float m_rotate = 50;

    GameObject Player;


    void Start ()
    {

        Player = GameObject.FindWithTag("Player");

    }
	
	void Update ()
    {
        //是否爆炸旋转
        if(m_isRotate)
        {
            RotateSelf();
        }

        
    }

    // 爆炸
    void Explode()
    {
        Vector3 centerPos = transform.position;

        GameObject[] objArr = new GameObject[4];

        for (int i = 0; i < objArr.Length; i++)
        {
            objArr[i] = Instantiate(m_explodeRock, centerPos, Quaternion.identity) as GameObject;
            objArr[i].AddComponent<Rigidbody2D>();
            objArr[i].GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            
            objArr[i].GetComponent<BoxCollider2D>().enabled = false;

            objArr[i].GetComponent<BoxCollider2D>().isTrigger = true;
            objArr[i].transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
            objArr[i].transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = true;
            objArr[i].transform.GetChild(2).GetComponent<BoxCollider2D>().isTrigger = true;

            objArr[i].transform.localScale = new Vector3(objArr[i].transform.localScale.x / 3, objArr[i].transform.localScale.y / 3, objArr[i].transform.localScale.z / 3);
            objArr[i].GetComponent<ExplodeRock>().m_isRotate = true;

            GameObject.Destroy(objArr[i],2);
        }

        objArr[0].GetComponent<Rigidbody2D>().velocity = new Vector3(-0.5f, 1, 0);
        objArr[1].GetComponent<Rigidbody2D>().velocity = new Vector3(0.5f, 1, 0);
        objArr[2].GetComponent<Rigidbody2D>().velocity = new Vector3(-0.5f, 0.5f, 0);
        objArr[3].GetComponent<Rigidbody2D>().velocity = new Vector3(0.5f, 0.5f, 0);
    }

    // 爆炸后的旋转
    void RotateSelf()
    {
        transform.Rotate(Vector3.forward,m_rotate * Time.deltaTime, Space.World);
    }

    //回调事件
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {            
            // Player 变大的时候才能撞爆炸
            if(Player.GetComponent<PlayerController>().m_isBig == true)
            {
                Explode();
                Destroy(this.gameObject);
            }
            else
            {
                // 装不动的动画效果
                transform.DOMoveY(transform.position.y + 0.06f, 0.4f).From(false);
            }
        }
    }

   


   
}
