using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Ease ease = Ease.InOutQuart;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0f, 0f, 90f), 1f).
            SetLoops(-1, LoopType.Yoyo).
            SetEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
