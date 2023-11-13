using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    bool location = false,trigger=false;
    Vector3 locationPos, startPos;
    GameObject OtherPart, CongrulationsText;
    GameObject[] AllParts;
    public string animName;
    int TotalReadyPart=0;
    private void Start()
    {
        AllParts = GameObject.FindGameObjectsWithTag("part");
        CongrulationsText = GameObject.FindGameObjectWithTag("Endtext");
        startPos=transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        
        float dis = Vector3.Distance(transform.position, other.transform.position);
        if (other.name == this.gameObject.name && dis < 0.02f && location==false)
        {
            OtherPart=other.gameObject;
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            trigger = true;
            locationPos=other.transform.position;
        }
        else if (other.name == this.gameObject.name && dis >= 0.02f)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            trigger = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == this.gameObject.name)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            trigger=false;
            location = false;
            
        }
    }
    private void OnMouseUp()
    {
        if (trigger)
        {
            location = true;
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger(animName);
            OtherPart.gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine("WaitAnim");
        }
        else { transform.position = startPos; }

        

    }

    IEnumerator WaitAnim()
    {

        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Animator>().enabled = false;
        transform.position = locationPos - new Vector3(0, 0, 0.02f);
        TotalReadyPart= 0;
        for (int i = 0; i < AllParts.Length; i++)//FinishCheck
        {
            
            if (AllParts[i].transform.localPosition.x < -0.1f)
            {
                TotalReadyPart++;
            }
        }
        if(TotalReadyPart >= 9)
        {
            CongrulationsText.GetComponent<Text>().text = "TEBRÝKLER MONTAJ TAMAMLANDI";
        }


    }

}
