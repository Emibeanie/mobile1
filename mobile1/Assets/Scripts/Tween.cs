using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tween : MonoBehaviour
{
    public Transform objectToTween;
    public float duration = 1.0f;

    private Vector3 startLocation;
    private Quaternion startRotation;
    
    void Start()
    {
        //store location and rotation
        startLocation = objectToTween.position;
        startRotation = objectToTween.rotation;
      
        //scale
        objectToTween.DOScale(Vector3.one * 1.5f, duration);
        //move
        objectToTween.DOMove(Vector3.down * 2f, duration).OnComplete(() => Debug.Log("Tween complete!"));
        //rotation
        objectToTween.DORotate(Vector3.forward * 0f, duration).OnStart(() => Debug.Log("Tween started!"));
       
    }
}
