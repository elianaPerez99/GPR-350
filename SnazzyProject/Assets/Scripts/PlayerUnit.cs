using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//Eliana
public class PlayerUnit : Particle2D
{
    private enum TypeGun
    {
        NORMAL,
        SPRING,
        ROD
    }
    //variables
    public GameObject ProjectilePrefabRef; //Cedric if you make one for the rod, make sure you drag from the prefab not an instance in game
    public GameObject SpringPrefabRef;
    public float maxZ = 180.0f;
    public float minZ = 0f;
    public int rotationIterator = 1;
    private TypeGun currentGun = TypeGun.NORMAL;

    //functions
    private void Start()
    {
        mIsPlayer = true;
    }
    // Update is called once per frame
    void Update()
    {
        Rotate();
        Shoot();
        ChangeProjectile();
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.rotation.eulerAngles.z + rotationIterator <= 360 && transform.rotation.eulerAngles.z + rotationIterator >= 180)
        {
            Vector3 rotationVector = transform.rotation.eulerAngles;
            rotationVector.z += rotationIterator;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.rotation.eulerAngles.z - rotationIterator <= 360 && (transform.rotation.eulerAngles.z - rotationIterator >= 180 || transform.rotation.eulerAngles.z < 0.0f))
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
            switch (currentGun)
            {
                case TypeGun.NORMAL:
                    {
                        float speed = 20.0f;
                        GameObject projectile = Instantiate(ProjectilePrefabRef, transform.position, transform.rotation);
                        projectile.GetComponent<Particle2D>().mAcc.y = -5.0f;
                        projectile.GetComponent<Particle2D>().mVel.x = speed * Mathf.Cos((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                        projectile.GetComponent<Particle2D>().mVel.y = speed * Mathf.Sin((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                        projectile.GetComponent<Particle2D>().mMass = 1.0f;
                        projectile.GetComponent<Particle2D>().mDamp = .99f;
                        projectile.GetComponent<Particle2D>().mShouldIgnoreForces = false;
                        break;
                    }
                case TypeGun.SPRING:
                    {
                        float speed = 20.0f;
                        GameObject projectile1 = Instantiate(ProjectilePrefabRef, transform.position, transform.rotation);
                        projectile1.GetComponent<Particle2D>().mAcc.y = -5.0f;
                        projectile1.GetComponent<Particle2D>().mVel.x = speed * Mathf.Cos((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                        projectile1.GetComponent<Particle2D>().mVel.y = speed * Mathf.Sin((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                        projectile1.GetComponent<Particle2D>().mMass = 1.0f;
                        projectile1.GetComponent<Particle2D>().mDamp = .99f;
                        projectile1.GetComponent<Particle2D>().mShouldIgnoreForces = false;
                        speed = 10f;
                        GameObject projectile2 = Instantiate(ProjectilePrefabRef, transform.position, transform.rotation);
                        projectile2.GetComponent<Particle2D>().mAcc.y = -5.0f;
                        projectile2.GetComponent<Particle2D>().mVel.x = speed * Mathf.Cos((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                        projectile2.GetComponent<Particle2D>().mVel.y = speed * Mathf.Sin((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                        projectile2.GetComponent<Particle2D>().mMass = 2.0f;
                        projectile2.GetComponent<Particle2D>().mDamp = .99f;
                        projectile2.GetComponent<Particle2D>().mShouldIgnoreForces = false;
                        GameObject springGen = Instantiate(SpringPrefabRef, transform.position, transform.rotation);
                        springGen.GetComponent<SpringForceGenerator>().mP1 = projectile1.GetComponent<Particle2D>();
                        springGen.GetComponent<SpringForceGenerator>().mP2 = projectile2.GetComponent<Particle2D>();
                        springGen.GetComponent<SpringForceGenerator>().restLength = .25f;
                        springGen.GetComponent<SpringForceGenerator>().springConstant = 10f;
                        break;
                    }
                case TypeGun.ROD:
                    {
                        break;
                    }
            }
        }
    }

    private void ChangeProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentGun == TypeGun.SPRING)
            {
                currentGun = TypeGun.NORMAL;
            }
            else
            {
                currentGun++;
                Debug.Log(currentGun.ToString());
            }
        }
    }
}
