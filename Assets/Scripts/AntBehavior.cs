using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AntBehavior : MonoBehaviour
{

    Vector3Int gridPosition;
    Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GameObject.FindObjectOfType<Tilemap>();
        gridPosition = tilemap.WorldToCell(transform.position);
        Debug.Log(gridPosition);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public IEnumerator moveTo(Vector3Int tile)
    {
        Vector3 endPosition = tilemap.GetCellCenterWorld(tile);
        Vector3 startPosition = transform.position;
        Vector3 currentPosition = startPosition;
        float speed = 1.5f;
        float completed = 0f;

        Debug.Log("Going  to " + endPosition);

        while (!currentPosition.Equals(endPosition) )
        {
            transform.position = Vector3.MoveTowards(startPosition, endPosition, completed);
            completed += speed * Time.deltaTime;
            currentPosition = transform.position;

            yield return null;
        }
        Debug.Log("Reached target");
    }
}
