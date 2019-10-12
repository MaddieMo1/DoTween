using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoTweenExample_ZH : MonoBehaviour
{
    public Image _Image;
    private Tween _Tween;
    private int _Number = 0;

    void Start()
    {
        //移动
        //transform.DOMove(Vector3.one * 5, 1);
        //transform.DOBlendableMoveBy(new Vector3(0, 3, 0), 1);
        //ransform.DOBlendableLocalMoveBy(new Vector3(0, 3, 0), 1);


        //缩放
        //transform.DOScaleY(3, 1);
        //transform.DOBlendableScaleBy(new Vector3(0, 3, 0), 1);


        //旋转
        //transform.DORotate(new Vector3(0, 30, 0), 1);
        //transform.DOBlendableRotateBy(new Vector3(0, 30, 0), 1);
        //transform.DOBlendableLocalRotateBy(new Vector3(0, 30, 0), 1);


        //中止
        //transform.DOPause();

        //相对移动
        //transform.DOMove(Vector3.one * 5, 2);
        //transform.DOMove(Vector3.one * 5, 2).From();

        //循环   -1 表示无限循环  
        //transform.DOMove(Vector3.one * 5, 2).SetRelative().SetLoops(-1, LoopType.Yoyo);

        //DOTween.To(() => transform.position, x => transform.position = x, new Vector3(0, 3, 0), 1).SetRelative().SetLoops(-1,LoopType.Yoyo);

        //混合移动 缩放 旋转

        //transform.DOBlendableLocalMoveBy(new Vector3(0, 3, 0), 1);
        //transform.DOBlendableRotateBy(new Vector3(0,30,0),1).SetRelative().SetLoops(-1, LoopType.Yoyo);


        // 2D 图片旋转
        //_Tween = _Image.transform.DOLocalRotate(new Vector3(0,0,90), 1,RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(1,LoopType.Incremental);

        //图片透明通道消减   停止播放
        //_Image.DOFade(0, 2).SetAutoKill(false);//.Pause()

        //图片颜色渐变
        //_Image.DOColor(RandomColor(), 2);

        //DoTween 回调函数执行
        _Tween = DOTween.To(() => _Number, x => _Number = x, 2, 5);

        //起始执行
        _Tween.OnStart(OnStarTween);

        //类似Update执行
        _Tween.OnUpdate(() => UpdateTween(_Number));

        //如果油循环执行的方法 则方法执行一次 如果不是循环 则完成执行
        _Tween.OnStepComplete(OnStepComplete);

        //完成所有回调函数 再执行
        _Tween.OnComplete(OnComplete);

        //最后执行 只回调一次
        _Tween.OnKill(OnKill);

    }

    public void OnClickStar()
    {
        //播放该物体所有的DOTween 动画
        DOTween.PlayAll();
    }

    public Color RandomColor()
    {
        Color _Color;
        _Color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        return _Color;
    }

    //起始执行
    private void OnStarTween()
    {
        print("OnStarTween");
    }

    //类似Update执行
    private void UpdateTween(int Number)
    {
        print(Number);
    }

    //如果油循环执行的方法 则方法执行一次 如果不是循环 则完成执行
    private void OnStepComplete()
    {
        print("OnStepComplete");
    }

    //完成所有回调函数 再执行
    private void OnComplete()
    {
        print("OnComplete");
    }

    //最后执行 只回调一次
    private  void OnKill()
    {
        print("OnKill");
    }
}
