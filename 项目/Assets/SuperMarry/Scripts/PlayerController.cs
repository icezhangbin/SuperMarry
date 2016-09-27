//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    
    private float m_hor;

    private Animator m_ant;

    private Rigidbody2D m_rig;

    public bool m_isBig = false;

    public float m_jumpSpeed = 3.5f;

    public bool m_isJumping = false;

    public int m_changeIndex = 0;

    bool m_controllerEnable = true;
       
    void Start ()
    {
        m_ant = GetComponent<Animator>();
        m_rig = GetComponent<Rigidbody2D>();          
    }
	
	
	void Update ()
    {
        // 1.移动监测
        if(m_controllerEnable)
        {
            m_hor = Input.GetAxis("Horizontal");
            PlayerMove();
        
        

            // 2.跳跃监测
            if (Input.GetKeyDown(KeyCode.Space) && !m_isJumping)
            {
                PlayerJump();
                m_isJumping = true;
            }

        }
    }

    // Player跳跃
    void PlayerJump()
    {
        m_rig.velocity = transform.up * m_jumpSpeed;
        m_ant.SetBool("an_jump", true);
    }

    // 变大变小
    public void ChangeSize()
    {
        
        // 变小
        if(m_isBig == true)
        {
            // 控制失活
            m_controllerEnable = false;

            // 改变
            Tweener tweener = transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f);
            tweener.OnComplete(DoTweenerSmallCall);
            
            // 设置当前状态
            m_isBig = false;
            
        }
        // 变大
        else if (m_isBig == false)
        {
            // 控制失活
            m_controllerEnable = false;

            Tweener tweener = transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f);            
            tweener.OnComplete(DoTweenerBigCall);

            m_isBig = true;                    
        }
    }

    // 变大
    void DoTweenerBigCall()
    {
        if(m_changeIndex == 6)
        {
            m_controllerEnable = true;
            m_changeIndex = 0;
            return;
        }

        if (transform.localScale == new Vector3(0.8f, 0.8f, 0.8f))
        {
            Tweener tweener = transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f);           
            tweener.OnComplete(DoTweenerBigCall);
        }
        else
        {
            Tweener tweener = transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f);           
            tweener.OnComplete(DoTweenerBigCall);
        }

        m_changeIndex++;
    }

    // 变小
    void DoTweenerSmallCall()
    {
        if (m_changeIndex == 6)
        {
            m_controllerEnable = true;
            m_changeIndex = 0;
            return;
        }

        if (transform.localScale == new Vector3(0.5f, 0.5f, 0.5f))
        {
            Tweener tweener = transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
            tweener.OnComplete(DoTweenerSmallCall);
        }
        else
        {
            Tweener tweener = transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f);
            tweener.OnComplete(DoTweenerSmallCall);
        }

        m_changeIndex++;
    }

    // Player加子弹
    void ChangeBullet()
    {

    }

    // Player移动
    void PlayerMove()
    {
        // 向右转向
        if (m_hor > 0)
        {
            // 设置Player的旋转角度为0
            transform.rotation = new Quaternion(0, 0, 0, 0);
            m_ant.SetBool("an_move", true);
        } 
        // 向左转向
        if (m_hor < 0)
        {
            // 设置Player的旋转角度为108
            transform.rotation = new Quaternion(0, 1, 0, 0);
            m_ant.SetBool("an_move", true);
        }
        // 原地不动
        if (m_hor == 0)
        {
            m_ant.SetBool("an_move", false);
        }

        // 移动
        transform.position += Vector3.right * 1 * m_hor * Time.deltaTime;
    }


    void OnCollisionStay2D(Collision2D other)
    {

        // 防止可以连跳
        ContactPoint2D[] pointArr = other.contacts;
       
        if (Mathf.Abs(pointArr[0].point.y - transform.position.y)<0.01f)
        {
            m_isJumping = false;
        }
        else
        {
            m_isJumping = true;
        }
                
        if (other.gameObject.tag.Equals("Plane") || other.gameObject.tag.Equals("Rock"))
        {            
            m_ant.SetBool("an_jump", false);
        }
    }

   
}
