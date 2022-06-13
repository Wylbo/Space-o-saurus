using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cloud : MonoBehaviour
{
    [SerializeField] protected float distanceToTravel = 10f;
    [SerializeField] protected Vector3 travelDirection = new Vector3(1,0,0);
    [SerializeField] protected float minSpeed = 1f;
    [SerializeField] protected float maxSpeed = 3f;

    protected SpriteRenderer spriteRenderer = null;
    protected Vector3 startPosition = default;
    protected Vector3 endPosition = default;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SendCloud()
    {
        StartCoroutine(Displacement());
    }

    public void SendCloud(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        SendCloud();
    }

    protected IEnumerator Displacement()
    {
        startPosition = transform.position;
        endPosition = transform.position + travelDirection * distanceToTravel;
        float elapsedTime = 0f;
        float speed = Random.Range(minSpeed, maxSpeed);

        while (elapsedTime <= speed)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / speed);
            yield return null;
        }

        Destroy(gameObject);
    }
}
