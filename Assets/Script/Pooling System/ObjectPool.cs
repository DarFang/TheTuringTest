using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<PooledObject> availableObjects = new List<PooledObject>();
    [SerializeField] private  PooledObject originalPrefab;
    [SerializeField] private int amountOfCopies;

    private void Awake() {
        for(int i = 0 ; i < amountOfCopies; i++)
        {
            CreatingCopy();
        }
    }
    private void CreatingCopy()
    {
        PooledObject tempObject = Instantiate(originalPrefab, transform);
        tempObject.LinkToPool(this);
        tempObject.gameObject.SetActive(false);
        availableObjects.Add(tempObject);
    }
    public PooledObject RetriveAvailableItem()
    {
        if(availableObjects.Count == 0)
        {
            CreatingCopy();
        }
        PooledObject tempObject = availableObjects[0];
        availableObjects.RemoveAt(0);
        tempObject.gameObject.SetActive(true);
        return tempObject;
    }
    public void ResetObject(PooledObject cloneObject)
    {
        cloneObject.gameObject.SetActive(false);
        availableObjects.Add(cloneObject);
    }
}
