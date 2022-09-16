using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createLine : MonoBehaviour
{

    [SerializeField] private AnimationCurve _animationCurve;

    // Start is called before the first frame update
    void Awake()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        var positions = new Vector3[]{
            new Vector3(0, 0, 0),               // 開始点
            new Vector3(8, 0, 0),               // 中継点
            new Vector3(8, -3, 0),              // 終了点
        };

        // 線の幅をアニメーションカーブを用いて設定する
        lineRenderer.widthCurve = _animationCurve;
        // lineRenderer.startWidth = 0.1f;                   // 開始点の太さを0.1にする
        // lineRenderer.endWidth = 0.1f;                     // 終了点の太さを0.1にする
        
        // 点の数を指定する
        lineRenderer.positionCount = positions.Length;
        // 線を引く場所を指定する
        lineRenderer.SetPositions(positions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
