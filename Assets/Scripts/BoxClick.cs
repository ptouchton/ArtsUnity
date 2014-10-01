using UnityEngine;
using System.Collections;

public class BoxClick : MonoBehaviour {

    //private fields
    private GameObject cubeObject { get; set; }

    // Use this for initialization
    public Material[] CustomMaterials;

    bool blnBoxClicked = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            if (collider.Raycast(Camera.mainCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //store off object for the onGui code
                cubeObject = hit.transform.gameObject;

                blnBoxClicked = true;

            }
        }

	
	}

    void OnGUI()
    {

        if (blnBoxClicked)
        {

            //make menu visible
            GUI.Box(new Rect(Screen.width - 140, 10, 110, 170), "Change Materials");

            //initial menu item top pos
            float top = 40; 

            //loop throug the CustomMaterials array and load up the menu options
            foreach (var mat in CustomMaterials){

                GUI.backgroundColor = mat.color;

                if (GUI.Button(new Rect(Screen.width - 125, (top), 80, 20), mat.name))
                {
                    //change material of the cube to the material
                    cubeObject.renderer.material = mat;

                    //lets close the window(i didn't like this behavior so i commented out)
                    //blnBoxClicked = false;
                }

                //increment top for next button position
                top += 25;

            }

        }
       
       

    }
}
