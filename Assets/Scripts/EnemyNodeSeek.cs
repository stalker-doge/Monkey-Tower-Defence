using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNodeSeek : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private GameObject[] nodes;

    // Start is called before the first frame update
    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNode();
    }
    private GameObject FindNode()
    {
       
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject node in nodes)
        {
            Vector3 diff = node.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = node;
                distance = curDistance;
            }
        }
        return closest;
    }
    private void RemoveNodeFromArray()
    {
        GameObject node = FindNode();
        List<GameObject> temp = new List<GameObject>(nodes);
        temp.Remove(node);
        nodes = temp.ToArray();
    }
    
    private void MoveToNode()
    {
        GameObject target = FindNode();
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if (transform.position == target.transform.position)
            {
                RemoveNodeFromArray();
            }
        }
    }
}
