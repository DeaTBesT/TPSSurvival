using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    [SerializeField] private bool isActivateOnStart;
    [SerializeField] private List<GameObject> armor;
    [SerializeField] private List<Transform> avaiablePlaces;
    private int maxArmor;
    private int countArmor;

    private void Start()
    {
        maxArmor = armor.Count;

        foreach (GameObject armorItem in armor)
        {
            armorItem.SetActive(isActivateOnStart);
            //avaiablePlaces.Add(armorItem.transform);
        }
    }

    public GameObject GetArmor()
    {
        if (armor.Count > 0)
        {
            int index = Random.Range(0, armor.Count);
            GameObject armorTmp = armor[index];
            armor.RemoveAt(index);
            return armorTmp;
        }
        else
        {
            return null;
        }
    }

    public void AddArmor(GameObject addedArmor)
    {
        addedArmor.SetActive(true);     
    }

    public bool IsAddArmor()
    {
        return armor.Count > 0 ? true : false;
    }
}
