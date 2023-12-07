using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Obj_spawner : MonoBehaviour
{
    public Camera cam;
    public List<GameObject> xaxaliqner;
    public GameObject animator;
    public GameObject Choose_buttone;
    public List<Button> buttones;
    public Sprite check;
    private int i = 0;
    private GameObject ancyal;

    public void durs()
    {
        animator.SetActive(false);
        Choose_buttone.SetActive(true);
    }

    public void Choose(int choose)
    {
        i = choose;
        spritum();
        buttones[i].image.sprite = check;
        durs();
    }

    public void Start_choose()
    {
        Choose_buttone.SetActive(false);
        animator.SetActive(true);
    }

    private void spritum()
    {
        for (int y = 0; y < buttones.Count; y++)
        {
            buttones[y].image.sprite = xaxaliqner[y].GetComponent<Ornament>().screenshot;
        }
    }

    private void Start()
    {
        spritum();
        buttones[i].image.sprite = check;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenCeter = new Vector2(cam.pixelWidth / 2, cam.pixelHeight / 2);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.gameObject.tag == "ket")
                {
                    try
                    {
                        GameObject stextsvats = Instantiate(xaxaliqner[i], hitInfo.collider.gameObject.transform.position, Quaternion.identity);

                        stextsvats.GetComponentInChildren<Collider>().enabled = true;

                        hitInfo.collider.enabled = false;
                    }
                    catch
                    {
                        Debug.Log("You can't");
                    }
                }
            }
        }
        else
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.gameObject.tag == "ket")
                {
                    Destroy(ancyal);
                    ancyal = Instantiate(xaxaliqner[i], hitInfo.collider.gameObject.transform.position, Quaternion.identity);
                }
                else 
                {
                    Destroy(ancyal);
                   
                    ancyal = Instantiate(xaxaliqner[i], cam.transform.position+cam.transform.forward, Quaternion.identity);
                    
                }
            }
        }
    }
}