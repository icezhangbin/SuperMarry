//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    private GameObject Player;
    private float m_forwordOffset;
    private float m_backOffset;
    private float m_speedX;
    private Transform m_forwordPos;
    private Transform m_backPos;

   
    void Start ()
    {

        m_forwordPos = transform.GetChild(0).transform;
        m_backPos = transform.GetChild(1).transform;
        Player = GameObject.FindWithTag("Player");
        print("m_forwordPos"+m_forwordPos.transform.position);
        print("m_backPos"+m_backPos.transform.position);
        
	}
	
	
	void Update ()
    {

        m_forwordOffset = m_forwordPos.position.x - Player.transform.position.x;
        m_backOffset = Player.transform.position.x - m_backPos.position.x;

        if (m_forwordOffset < 0)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(Player.transform.position.x, transform.position.y, transform.position.z),0.2f);
        }

        if(m_backOffset<0)
        {
            Player.transform.position = new Vector3(m_backPos.position.x, Player.transform.position.y, Player.transform.position.z);
        }
	}
}
