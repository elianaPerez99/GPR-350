using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Eliana
public class PlayerUnit : Particle2D
{
    //variables
    public GameObject ProjectilePrefabRef;
    public float maxZ = 180.0f;
    public float minZ = 0f;
    public int rotationIterator = 1;

    private enum TypeGun //havent implemented switching between the three yet
    {
        NORMAL,
        SPRING,
        ROD
    }

    //functions

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Shoot();
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.rotation.eulerAngles.z + rotationIterator <= 360 && transform.rotation.eulerAngles.z + rotationIterator >= 180)
        {
            Vector3 rotationVector = transform.rotation.eulerAngles;
            rotationVector.z += rotationIterator;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.rotation.eulerAngles.z - rotationIterator <= 360  && (transform.rotation.eulerAngles.z - rotationIterator >= 180 || transform.rotation.eulerAngles.z < 0.0f))
        {
            Vector3 rotationVector = transform.rotation.eulerAngles;
            rotationVector.z -= rotationIterator;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }

    private void Shoot()
    {
        //later add check enum for type of gun ect
        if (Input.GetKeyDown(KeyCode.W))
        {
            float speed = 40.0f;
            GameObject projectile = Instantiate(ProjectilePrefabRef, transform.position, transform.rotation);
            projectile.GetComponent<Particle2D>().mAcc.y = -5.0f;
            projectile.GetComponent<Particle2D>().mVel.x = speed * Mathf.Cos((90+transform.rotation.eulerAngles.z) *Mathf.Deg2Rad);
            projectile.GetComponent<Particle2D>().mVel.y = speed * Mathf.Sin((90+transform.rotation.eulerAngles.z )* Mathf.Deg2Rad);
            projectile.GetComponent<Particle2D>().mMass = 1.0f;
            projectile.GetComponent<Particle2D>().mDamp = .99f;
            projectile.GetComponent<Particle2D>().mShouldIgnoreForces = false;
        }
    }
}
