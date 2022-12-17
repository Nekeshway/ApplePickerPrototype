using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBuskets = 3;
    public float basketBottomY = -0.001f;
    public float basketSpacingY = 0.001f;
    public List<GameObject> basketList;
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i< numBuskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

   public void AppleDestroyed()
    {
        GameObject[] tAppleArray =  GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray) 
        {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tbasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tbasketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
 
}
