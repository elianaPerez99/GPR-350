using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//Eliana & Cedric
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
    public GameObject ParticleRodPrefabRef;
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
        if (Input.GetKeyDown(KeyCode.Return))
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
                  float speed1 = 20.0f;
                  float speed2 = 20.0f;
                  int rodLength = 3;
                  float penetration = 10.0f;
                  float restitution = 1.0f;

                  float mass1 = 1.0f;
                  float mass2 = 2.0f;
                  float grav = -5.0f;
                  
                   //Create 1st Particle
                   GameObject projectile1 = Instantiate(ParticleRodPrefabRef, transform.position, transform.rotation);
                   projectile1.GetComponent<Particle2D>().mAcc.y = grav;
                   projectile1.GetComponent<Particle2D>().mVel.x = speed1 * Mathf.Cos((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                   projectile1.GetComponent<Particle2D>().mVel.y = speed1 * Mathf.Sin((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                   projectile1.GetComponent<Particle2D>().mMass = mass1;
                   projectile1.GetComponent<Particle2D>().mDamp = .99f;
                   projectile1.GetComponent<Particle2D>().mShouldIgnoreForces = false;

                   Vector3 projectile2Position = new Vector3(projectile1.transform.position.x + rodLength, transform.position.y, 0.0f);

                   //Create 2nd Particle
                   GameObject projectile2 = Instantiate(ParticleRodPrefabRef, projectile2Position, transform.rotation);
                   projectile2.GetComponent<Particle2D>().mAcc.y = grav;
                   projectile2.GetComponent<Particle2D>().mVel.x = speed2 * Mathf.Cos((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                   projectile2.GetComponent<Particle2D>().mVel.y = speed2 * Mathf.Sin((90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad);
                   projectile2.GetComponent<Particle2D>().mMass = mass2;
                   projectile2.GetComponent<Particle2D>().mDamp = .99f;

                  //Create Rod Connections
                  Particle2DRod rodConnection = projectile1.GetComponent<Particle2DRod>();
                  rodConnection.mObj1 = projectile1.GetComponent<Particle2D>();
                  rodConnection.mObj2 = projectile2.GetComponent<Particle2D>();

                  rodConnection.mLength = rodLength;
                  rodConnection.mPenetration = penetration;
                  rodConnection.mRestitution = restitution;

                  //Create Second Rod
                  Particle2DRod rodConnection2 = projectile2.GetComponent<Particle2DRod>();
                  rodConnection.mObj2 = projectile1.GetComponent<Particle2D>();
                  rodConnection.mObj1 = projectile2.GetComponent<Particle2D>();

                  rodConnection.mLength = rodLength;
                  rodConnection.mPenetration = penetration;
                  rodConnection.mRestitution = restitution;

                  break;
                }
            }
        }
    }

    private void ChangeProjectile()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentGun == TypeGun.SPRING)
            {
               currentGun = TypeGun.ROD;
            }
            else if (currentGun == TypeGun.ROD)
            {
               currentGun = TypeGun.NORMAL;
            }
            else if (currentGun == TypeGun.NORMAL)
            {
               currentGun = TypeGun.SPRING;
            }
            else
            {
               currentGun++;
               Debug.Log(currentGun.ToString());
            }
            Debug.Log(currentGun.ToString());
        }
    }
}
