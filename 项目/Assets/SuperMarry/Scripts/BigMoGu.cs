//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class BigMoGu : MonoBehaviour
{

    public enum MoGuType
    {
        BigMogu = 1, LifeMogu = 2
    }

    Rigidbody2D rig;
    public MoGuType m_moguType;
    

    void Start ()
    {

        rig = transform.GetComponent<Rigidbody2D>();
        rig.velocity = Vector3.right * 1;


    }
	
	
	void Update ()
    {
	    if(rig.velocity.magnitude == 0)
        {           
            rig.velocity = Vector3.right * 1f;
        }

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag.Equals("Player"))
        {
            rig.velocity = Vector3.zero;
            GameObject player = other.gameObject;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            PlayerController playerControllerScript = player.GetComponent<PlayerController>();

            if(m_moguType == MoGuType.BigMogu)
            {                
                if (playerControllerScript.m_isBig == false)
                {
                    playerControllerScript.ChangeSize();
                }
            }
            else if(m_moguType == MoGuType.LifeMogu)
            {
                playerControllerScript.ChangeSize();
                print("这是命蘑菇");
                
            }
            

            Destroy(gameObject);
        }
        else if(other.gameObject.tag.Equals("Rock"))
        {
            rig.velocity = Vector3.zero;
            rig.velocity = Vector3.left * 1;
        }
    }
}
