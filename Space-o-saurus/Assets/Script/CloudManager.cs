using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudManager : MonoBehaviour
{
    [SerializeField] protected Transform upStartPosition = null;
    [SerializeField] protected Transform downStartPosition = null;
    [SerializeField] protected Cloud cloudPrefab = null;
    [SerializeField] protected List<Sprite> cloudsSprites = new List<Sprite>();
    [SerializeField] protected bool startAtPlay = true;
    [SerializeField] protected float spawnRate = 3f;

    protected Action DoAction = null;
    protected float elapsedTime = 0f;

    private void Awake()
    {
        if (startAtPlay) SetModeNormal();
    }

    public void SetModeVoid()
    {
        DoAction = DoActionVoid;
    }

    public void DoActionVoid()
    {
        
    }

    public void SetModeNormal()
    {
        DoAction = DoActionNormal;
    }

    public void DoActionNormal()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnRate)
        {
            elapsedTime = 0f;
            SpawnCloud();
        }
    }

    protected void SpawnCloud()
    {
        Vector3 pos = Vector3.Lerp(upStartPosition.position, downStartPosition.position, Random.value);
        Cloud cloud = Instantiate(cloudPrefab).GetComponent<Cloud>();

        cloud.transform.position = pos;
        cloud.SendCloud(cloudsSprites[Random.Range(0, cloudsSprites.Count - 1)]);
    }

    private void Update()
    {
        DoAction();
    }

    private void OnDrawGizmosSelected()
    {
        if(upStartPosition != null)
        {
            Gizmos.color = Color.blue;
            Vector3 upPos = upStartPosition.position;
            Gizmos.DrawSphere(upPos, 1f);
        }

        if (downStartPosition != null)
        {
            Gizmos.color = Color.blue;
            Vector3 downPos = downStartPosition.position;
            Gizmos.DrawSphere(downPos, 1f);
        }

        if (downStartPosition && upStartPosition)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(downStartPosition.position, upStartPosition.position);
        }
    }
}
