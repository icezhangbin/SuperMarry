//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CoinAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MoveUp()
    {
        Destroy(gameObject,0.6f);
        // 撞击时的动画效果
        transform.DOMoveY(transform.position.y + 0.3f, 0.6f).From(false);
    }
}
