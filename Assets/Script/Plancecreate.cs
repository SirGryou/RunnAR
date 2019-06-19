using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plancecreate : MonoBehaviour
{
    public Vector3 startPos, endPos;
    public GameObject A, B;
    public GameObject PlaneFace;
    public bool create;
    public bool test;


    void Start()
    {
        //GameObject Quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        // Quad.transform.localScale = new Vector3((a.x - a.y),(b.z - b.x), 1);
        //Vector3 centerPos = new Vector3(a.x + b.x, a.y + b.y) / 2f;
     
    }
        
    // Update is called once per frame
    void Update()
    {
        startPos = A.transform.position;
        endPos = B.transform.position;
        if (create == true)
      {
            SpawnGround(startPos, endPos);
            create = false;
      }
    }

    void SpawnGround(Vector3 startPos, Vector3 endPos)
    {
        GameObject ground = Instantiate(PlaneFace);
        //PlaneFace.gameObject.AddComponent<DisplayWebcam>();
       
        Vector3 centerPos = new Vector3(startPos.x + endPos.x, startPos.y + endPos.y) / 2;

        float scaleX = Mathf.Abs(startPos.x - endPos.x);
        float scaleY = Mathf.Abs(startPos.y - endPos.y);

       // centerPos.x -= 0.5f;
       // centerPos.y -= 0.5f;
        ground.transform.position = centerPos;
        ground.transform.localScale = new Vector3(scaleX, scaleY, 1);

        if (test == true)
        {
            test = false;
            ground.gameObject.AddComponent<DisplayWebcam>();
            
        }


    }
}
