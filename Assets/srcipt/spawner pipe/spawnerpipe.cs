using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerpipe : MonoBehaviour
{
    [SerializeField]//hien thi ra man hinh
    private GameObject pipeHoler;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        
    }

    // Update is called once per frame
     IEnumerator Spawner()
    {
        
        yield return new WaitForSeconds(2);
        Vector3 temp = pipeHoler.transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);
        Instantiate(pipeHoler, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
    //OnCollisionEnter2D(Collision2D target)/ /k co tick is trigger
     
}
