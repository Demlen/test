using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class test : MonoBehaviour
{
    [Tooltip("Minimal number of Line in diagram")]
    public int minLine;

    [Tooltip("Children od diagram")]
    public List<Transform> diagramLines = new List<Transform>();

    //dodać notyfiakcje
    //poniżej zmienić na private

    public Vector2 maxHeightLenght; 
    private List<int> collectDiagramLineHeight = new List<int>();
    public int diagramAvarge;
    public int diagramAvargeProc;

    void Start()
    {
        //get all line in tables
        if (transform.childCount > minLine)
        {
            foreach (Transfom child in transfrom)
            {
                diagramLines.Add(child);
            }
            if (mainTable.childCount > minLine)
            {
                Debug.Log("Line in tables is less tahan {0}", minLine);
            }
        }

        //get max height from other script
        // maxHeightLenght = transform.parent.gameObject.GetComponent<>().maxHeightLenght;

        if (maxHeightLenght.x == 0 || maxHeightLenght.y == 0) Debug.Log("Set max Height and Lenght to diagram line");

        //Start randomise diagram line
        StartCoroutine(RandomiseDiagram);
    }

    void RandomiseLine(Transform dLine)
    {
        //set random value for one line in diagram
        dLine.transform.localScale = new Vector2(maxHeightLenght.x, Random.Range(0, maxHeightLenght.y));
    }


    IEnumerator RandomiseDiagram()
    {
        Transform randomChild;
        while (true)
        {
            //loop: get random child, change his value and wait
            randomChild = diagramLines[Random.Range(0, diagramLines.Count)];
            RandomiseLine(randomChild);
            yield return new WaitForSeconds(2);
        }
    }

    void GetDataFromChild()
    {
        collectDiagramHeight.Clear;
        int count = 0;
        float h = 0;

        foreach (Transform child in diagramLines)
        {
            collectDiagramLineHeight.Add(child.transform.localscale.y);
            count++;
            h += child.transform.localscale.y;
        }
        diagramAvarge = h / count as int;
        diagramAvargeProc = (diagramAvarge / maxHeightLenght.y) * 100 as int;
    }
   
    /*
    void GetData( Sender transform )
    {
        GetDataFromChild();
    }
    */

    void Update()
    {

    }
}