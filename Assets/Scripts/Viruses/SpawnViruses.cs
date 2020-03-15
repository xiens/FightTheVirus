using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnViruses : MonoBehaviour
{
    [SerializeField]
    private GameObject [] virusPrefabs;

    [SerializeField]
    private float spawnRangeY = 5.0f;

    [SerializeField]
    private float midRangeY = 1.0f;

    [SerializeField]
    private float distToPlayerX = 10.0f;

    [SerializeField]
    private float timeBetweenWaves = 2.0f;

    private GameObject [] viruses;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(virusPrefabs.Length > 0)
        {
            viruses = new GameObject[virusPrefabs.Length];

            for (int i = 0; i < virusPrefabs.Length; i++)
            {
                viruses[i] = Instantiate(virusPrefabs[i], new Vector3(0, 100 + i*5, 0), Quaternion.identity);
            }
            player = GameObject.FindGameObjectWithTag("Player");

            StartCoroutine("spawn_viruses");
        }
        else
        {
            Debug.Log("Assign some virus prefabs!");
        }

    }

    IEnumerator spawn_viruses()
    {
        while (true)
        {
            float virusX = player.transform.position.x + distToPlayerX;
            float virusY = Random.Range(midRangeY - spawnRangeY * 0.5f, midRangeY + spawnRangeY * 0.5f);

            int i = Random.Range(0, virusPrefabs.Length);

            viruses[i].transform.position = new Vector2(virusX, virusY);

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
