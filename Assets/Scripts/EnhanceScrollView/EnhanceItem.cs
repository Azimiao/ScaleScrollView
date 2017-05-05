﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnhanceItem : MonoBehaviour {

    // 在ScrollViewitem中的索引
    // 定位当前的位置和缩放
    public int scrollViewItemIndex = 0;
    public bool inRightArea = false;

    private Vector3 targetPos = Vector3.one;
    private Vector3 targetScale = Vector3.one;

    private Transform mTrs;
    private Image mImage;


    void Awake()
    {
        mTrs = this.transform;
        mImage = this.GetComponent<Image>();
    }

    void Start()
    {
		this.gameObject.GetComponent<Button>().onClick.AddListener(delegate () { OnClickScrollViewItem(); });
	}

    // 当点击Item，将该item移动到中间位置
    private void OnClickScrollViewItem()
    {
        EnhancelScrollView.GetInstance().SetHorizontalTargetItemIndex(scrollViewItemIndex);
    }

    /// <summary>
    /// 更新该Item的缩放和位移
    /// </summary>
    public void UpdateScrollViewItems(float xValue, float yValue, float scaleValue)
    {
        targetPos.x = xValue;
        targetPos.y = yValue;
        targetScale.x = targetScale.y = scaleValue;

        mTrs.localPosition = targetPos;
        mTrs.localScale = targetScale;
    }

    public void SetSelectColor(bool isCenter)
    {
        if (mImage == null)
            mImage = this.GetComponent<Image>();
		
        if (isCenter)
            mImage.color = Color.white;
        else
            mImage.color = Color.gray;
    }
}
