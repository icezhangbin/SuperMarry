//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BlinkRock : MonoBehaviour
{
    public enum RockType
    {
        Score = 0, BigMogu = 1, LifeMogu = 2, Bullet = 3
    }

    private bool m_isFinish = false;
    public RockType m_type = 0;
    public Sprite[] m_blinkRockArr;
    public Sprite m_finish;
    private int m_index = 0;
    float m_timer = 0;
    float m_targetTimer = 0.4f;
    public GameObject MoGu;
    public Sprite m_lifeMoguSprite;
    public GameObject CoinPrefab;
    

    public bool m_isUser = false;


    void Start()
    {

    }


    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_index > 2)
        {
            m_index = 0;
        }

        if (m_timer > m_targetTimer && !m_isFinish)
        {
            transform.GetComponent<SpriteRenderer>().sprite = m_blinkRockArr[m_index];
            m_index++;
            m_timer = 0;
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {

            switch (m_type)
            {
                case RockType.Score:

                    if(m_isUser == false)
                    {
                        GameObject MoveCoin = Instantiate(CoinPrefab, transform.position + Vector3.up * 0.15f, Quaternion.identity) as GameObject;
                        MoveCoin.GetComponent<CoinAnimation>().MoveUp();
                        m_isUser = true;
                    }
                    
                    //方块闪烁结束
                    StopChangeSprite();
                    break;

                // 创建长大蘑菇
                case RockType.BigMogu:

                    // 是否已经撞过
                    if(m_isUser == false)
                    {
                        CreateBigMoGu();

                        // 撞击时的动画效果
                        transform.DOMoveY(transform.position.y + 0.06f, 0.4f).From(false);

                        StopChangeSprite();

                        m_isUser = true;
                    }

                    break;

                // 创建命蘑菇
                case RockType.LifeMogu:

                    // 是否已经撞过
                    if (m_isUser == false)
                    {
                        CreateLifeMoGu();

                        StopChangeSprite();

                        m_isUser = true;
                    }
                    
                    break;

                // 创建子弹花
                case RockType.Bullet:
                    


                    StopChangeSprite();
                    break;
            }
        }
    }

    // 创建命蘑菇
    void CreateLifeMoGu()
    {
        GameObject lifemogu = Instantiate(MoGu, transform.position + Vector3.up * 0.15f, Quaternion.identity) as GameObject;
        lifemogu.GetComponent<SpriteRenderer>().sprite = m_lifeMoguSprite;
        lifemogu.GetComponent<BigMoGu>().m_moguType = BigMoGu.MoGuType.LifeMogu;
    }

    // 创建长大蘑菇
    void CreateBigMoGu()
    {
        GameObject mogu = Instantiate(MoGu, transform.position + Vector3.up * 0.15f, Quaternion.identity) as GameObject;
        mogu.GetComponent<BigMoGu>().m_moguType = BigMoGu.MoGuType.BigMogu;
    }

    // 创建子弹花
    void CreateBulletFlower()
    {

    }

    // 停止方块闪速
    void StopChangeSprite()
    {
        m_isFinish = true;
        transform.GetComponent<SpriteRenderer>().sprite = m_finish;
    }

}
