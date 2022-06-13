using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Spaceship : MonoBehaviour
{
    public event Action<Spaceship> OnLanded = null;

    [Header("Settings")]
    [SerializeField] protected float launchHeight = 10f;
    [SerializeField] protected float launchTime = 3f;
    [SerializeField] protected AnimationCurve launchCurve = default;

    [Header("Animation Settings")]
    [SerializeField] protected List<ParticleSystem> launchParticules = null;

    [Header("Animation Settings")]
    [SerializeField] protected Animator animator = null;
    [SerializeField] protected string lauchTriggerName = "Launch";

    protected Vector3 lauchingDirection = new Vector3(0, 1, 0);
    protected Vector3 startPosition = default;
    protected Vector3 endPosition = default;
    protected Coroutine coroutine = null;

    private void Awake()
    {
        startPosition = transform.position;
        endPosition = startPosition + lauchingDirection * launchHeight;
    }

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    [ContextMenu("Launch")]
    public void Lauch()
    {
        animator.SetTrigger(lauchTriggerName);
        if (launchParticules.Count > 0)
        {
            foreach (ParticleSystem ps in launchParticules)
            {
                ps.Play();
            }
        }

        if (coroutine != null)
        {
            Debug.LogWarning("Lauch coroutine already started");
            return;
        }
        StartCoroutine(LauchAnim());
    }

    protected IEnumerator LauchAnim()
    {
        float elapsedTime = 0f;
        while(elapsedTime < launchTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, launchCurve.Evaluate(elapsedTime / launchTime));

            yield return null;
        }

        transform.position = endPosition;
        coroutine = null;
        EndLauch();
    }

    protected void EndLauch()
    {
        OnLanded?.Invoke(this);
        if (launchParticules.Count > 0)
        {
            foreach (ParticleSystem ps in launchParticules)
            {
                ps.Stop();
            }
        }
    }

}
