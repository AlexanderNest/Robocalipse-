using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rival : MonoBehaviour {

	public Animator RAnimation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RStop()
{
	RAnimation.SetInteger("Rival", 0);
}

public void SuperAttack()
{
	RAnimation.SetInteger("Rival", 1);
}

public void Attack()
{
	RAnimation.SetInteger("Rival", 2);
}

public void LegAttack()

{
	RAnimation.SetInteger("Rival", 3);
}

    public void Pause()
    {
        Time.timeScale = 0;
    }


}
