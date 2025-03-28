using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChainLightningShoot : MonoBehaviour
{
    [SerializeField] float refreshRate = 0.01f;
    [SerializeField][Range(1, 10)] int maximumEnemiesinChain = 5;
    [SerializeField] float delayBetweenEachChain = 0.2f;
    [SerializeField] Transform playerFirePoint;
    //[SerializeField] EnemyDetector playerEnemyDectetor;
    [SerializeField] GameObject lineRendererPrefab;
    [SerializeField] List<GameObject> pillar;

    int test;
    bool shooting;
    bool _shot;
    float counter = 1;
    int _nbPillar = 0;
    List<GameObject> spawnedLineRenderers = new List<GameObject>();
    List<GameObject> enemiesInChain = new List<GameObject>();

    public AudioSource AudioSource;
    public AudioClip laserBeam;

    void Update()
    {
        
    }

    public void CanShoot()
    {
        //if (playerEnemyDectetor.GetEnemiesInRange().Count > 0)
        {
            if (!shooting)
            {
                StartShooting();
                
            }
            else
            {
                StopShooting();
            }
        }
    }

    public void StartShooting()
    {
        shooting = true;
        

       StartCoroutine(ShootWithDelay());
    }

    private IEnumerator ShootWithDelay()
    {
        
        _nbPillar = 0;
        for (int i = 0; i < pillar.Count; i++)
        {
            _shot = true;
            if (i == 0)
            {
                NewLineRenderer(playerFirePoint, pillar[i].transform);
                
            }
            else
            {
                NewLineRenderer(pillar[i - 1].transform, pillar[i].transform);
            }

            _nbPillar++;

            yield return new WaitForSeconds(0.5f);

        }
        
        // Relier le dernier pilier au premier
        NewLineRenderer(pillar[^1].transform, playerFirePoint);
    }


   

    private void NewLineRenderer(Transform startPos , Transform endPos)
    {

        AudioSource.PlayOneShot(laserBeam);
        GameObject lineR = Instantiate(lineRendererPrefab);
        spawnedLineRenderers.Add(lineR);
        StartCoroutine(UpdateLineRenderer(lineR, startPos, endPos));

      

    }

    IEnumerator UpdateLineRenderer(GameObject lineR, Transform startPos, Transform endPos)
    {
        while(shooting && _shot && lineR != null)
        {
            
            lineR.GetComponent<LineRendererController>().SetPosition(startPos, endPos);

            yield return new WaitForSeconds(refreshRate);
        }

    }

    public void StopShooting()
    {
        shooting = false;
        _shot = false;
        counter = 1;

        for (int i = 0; i < spawnedLineRenderers.Count; i++) 
        {
            Destroy(spawnedLineRenderers[i]);
        }

        spawnedLineRenderers.Clear();
        enemiesInChain.Clear(); 
    }


}
