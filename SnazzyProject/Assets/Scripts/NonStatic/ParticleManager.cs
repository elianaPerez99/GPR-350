
using System.Collections.Generic;
using UnityEngine;
//Eliana & Cedric

public class ParticleManager : MonoBehaviour
{
    public List<Particle2D> mParticles = new List<Particle2D>();
    public GameObject ParticlePrefabRef;
    public int numPart = 5;

    private void Awake()
    {
        SpawnParticle2D();
    }

    private void FixedUpdate()
   {
        foreach (Particle2D part1 in mParticles)
        {
            if (!part1.mIsPlayer)
            {
                foreach (Particle2D part2 in mParticles)
                {
                        if (!part1.Equals(part2) && !part2.mIsPlayer)
                        {
                            if (CollisionDetector.DetectCollision(part1, part2))
                            {
                                Destroy(part1.gameObject);
                                Destroy(part2.gameObject);
                            }
                        }
                }
            }
        }
   }

    private void SpawnParticle2D()
    {
        float x, y;
        for (int i = 0; i < numPart; i++)
        {
            x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 2, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - 1);
            y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + 1, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 1);
            GameObject temp = Instantiate(ParticlePrefabRef);
            temp.GetComponent<Particle2D>().mVel.x = 0;
            temp.GetComponent<Particle2D>().mVel.y = 0;
            temp.GetComponent<Particle2D>().mMass = 1.0f;
            temp.GetComponent<Particle2D>().mDamp = .99f;
            temp.transform.position = new Vector3(x, y, 0);
        }
    }


}
