using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private float AnimMaxDelay;
    [SerializeField] private int HitScore;
    [SerializeField] private AudioSource AudioSource;

    private void Awake()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        float delay = Random.Range(0, AnimMaxDelay);
        
        yield return new WaitForSeconds(delay);

        Animator.SetTrigger("animate");
    }

    public void Hit()
    {
        AnimatorStateInfo currentState = Animator.GetCurrentAnimatorStateInfo(0);

        if (currentState.IsName("idle"))
        {
            AudioSource.Play();
            Animator.SetTrigger("hit");
            GameManager.Instance.ScoreManager.AddScore(HitScore);
        }
    }
}
