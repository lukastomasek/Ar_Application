using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField] Animator anim;

    const string fight_id = "attack_1";

    private void Start()
    {
        Debug.Log("<color=green> Testing </color>");

        if (anim == null)
        {
            anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }
    }

    public void PlayFightAnimation() => anim.Play(fight_id);
   
}
