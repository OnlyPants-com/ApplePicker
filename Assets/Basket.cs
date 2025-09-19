using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        //Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current sceen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        // If this line causes a NullreferenceException, select the Main Camera
        // in the Hierarchy and set its tag to MainCampera in the Inspector
        mousePos2D.z = -Camera.main.transform.position.z;

        // convert the point from 2D screen spae into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple") || collidedWith.CompareTag("Branch"))
        {
            Destroy(collidedWith);
            //Increase the score
            if (collidedWith.CompareTag("Apple"))
            {
                scoreCounter.score += 100;
            }

            else if (collidedWith.CompareTag("Branch"))
            {
                
            }
            
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
