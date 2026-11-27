using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private Transform treePrefab;

    public HashSet<int> Init(float z)
    {
        //Placing the obstacle at the loaction provided
        transform.position = new Vector3(0, 0, z);

        //Setting obstacles outside of the game area
        HashSet<int> loactions = new() { -6, 6 };

        //Populate with some obstacles
        int numTress = Random.Range(1, 5);

        for (int i = 0; i < numTress; i++)
        {
            //Create a new tree object
            Transform tree = Instantiate(treePrefab, transform);

            //Put in random position
            int xPos = Random.Range(-5, 6);
            tree.position = new Vector3(xPos, 0.2f, z);

            //Record the loaction in the HashSet
            loactions.Add(xPos);
        }
        return loactions;
    }
}
