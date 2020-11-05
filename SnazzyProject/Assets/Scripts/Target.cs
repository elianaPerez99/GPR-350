using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Eliana
public class Target : Particle2D
{
    //variables
    public Vector2 xRange;
    public Vector2 yRange;
    //functions
    // Start is called before the first frame update
    void Start()
    {
        mIsTarget = true;
        Respawn();
    }

    public void Respawn()
    {
        Vector3 tempPos = new Vector3();
        tempPos.x = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 2, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - 1);
        tempPos.y = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + 1, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 1);
        transform.position = tempPos;
        xRange = new Vector2(transform.position.x - .75f, transform.position.x + .75f);
        yRange = new Vector2(transform.position.y - .75f, transform.position.y + .75f);
    }
}
