using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyAnimationTestController : MonoBehaviour {


    public GameObject gameObj;

    Animation animation;
	void Start () {
        animation = gameObj.GetComponent<Animation>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayTheAnimation()
    {
        animation.Play("WeakIdle_nan",AnimationPlayMode.Mix);
    }

}
