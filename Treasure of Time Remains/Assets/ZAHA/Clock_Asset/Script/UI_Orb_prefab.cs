using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Orb_prefab : MonoBehaviour
{
    

    GameObject UI_Obj;
    GameObject prefab;
    public GameObject[] orb_clone;
    // Start is called before the first frame update
    [SerializeField]
    public int max_obj;
    void Start()
    {
        UI_Obj = GameObject.Find("UI_Orb");
        prefab = (GameObject)Resources.Load("Prefab/UI_Magic_Orb");
        for (int i = 0; i < max_obj; i++)  {
            orb_clone = new GameObject[max_obj];
            orb_clone[i] = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            orb_clone[i].gameObject.transform.SetParent(UI_Obj.transform, false);

            Debug.Log(orb_clone[i].gameObject.transform);
        }
    }
}
