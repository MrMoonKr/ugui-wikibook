﻿using UnityEngine;

public class TableViewCell<T> : ViewController	// ViewController 클래스를 상속한다
{
    /// <summary>
    /// 셀의 내용을 갱신하는 가상 메소드.
    /// 실제 처리는 상속한 클래스에서 구현한다.
    /// </summary>
    /// <param name="itemData">대응하는 데이터 항목</param>
    public virtual void UpdateContent( T itemData )
    {
        // 실제 처리는 상속한 클래스에 구현한다
    }

    /// <summary>
    /// 셀에 대응하는 리스트 항목의 인덱스
    /// </summary>
    public int DataIndex { get; set; }

    /// <summary>
    /// 셀의 높이
    /// </summary>
    public float Height
    {
        get
        { 
            return CachedRectTransform.sizeDelta.y; 
        }
        set
        {
            Vector2 sizeDelta = CachedRectTransform.sizeDelta;
            sizeDelta.y = value;

            CachedRectTransform.sizeDelta = sizeDelta;
        }
    }

    /// <summary>
    /// 셀의 위쪽 끝의 위치
    /// </summary>
    public Vector2 Top
    {
        get
        {
            Vector3[] corners = new Vector3[4];
            CachedRectTransform.GetLocalCorners( corners );

            return CachedRectTransform.anchoredPosition + new Vector2( 0.0f, corners[ 1 ].y );
        }
        set
        {
            Vector3[] corners = new Vector3[4];
            CachedRectTransform.GetLocalCorners( corners );

            CachedRectTransform.anchoredPosition = value - new Vector2( 0.0f, corners[ 1 ].y );
        }
    }

    /// <summary>
    /// 셀의 아래쪽 끝의 위치
    /// </summary>
    public Vector2 Bottom
    {
        get
        {
            Vector3[] corners = new Vector3[4];
            CachedRectTransform.GetLocalCorners( corners );

            return CachedRectTransform.anchoredPosition + new Vector2( 0.0f, corners[ 3 ].y );
        }
        set
        {
            Vector3[] corners = new Vector3[4];
            CachedRectTransform.GetLocalCorners( corners );

            CachedRectTransform.anchoredPosition = value - new Vector2( 0.0f, corners[ 3 ].y );
        }
    }
}
