using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionsInterfaceAnimation : MonoBehaviour
{
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private Animator animator;
    public void FadeIn(){
        animator.Play("BGFadeIn");
    }

    public void FadeOut()
    {
        animator.Play("BGFadeOut");
    }

    private void Start()
    {
        animator = backgroundImage.GetComponent<Animator>();
        FadeOut();
        
    }






}
