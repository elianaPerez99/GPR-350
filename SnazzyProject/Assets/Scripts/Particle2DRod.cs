using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2DRod : Particle2DLink
{
	public int mLength;
	public int mRestitution;
	public int mPenetration;


	public override void CreateContacts(List<Particle2DContact> mContacts)
	{
		float rodLength = GetCurrentLength();

		//If the Rod length is correct
		if (rodLength == mLength)
		{
			//do nothing since it is the right length
		}
		else
		{
			Vector3 diff = mObj2.transform.position - mObj1.transform.position;
			Vector3.Normalize(diff);

			float penetration = 0;

			if (rodLength > mLength)// if the rod is smaller
			{
				penetration = rodLength - mLength;
			}
			else if (rodLength < mLength)// if the rod is longer/larger
			{
				diff *= -1;
				penetration = mLength - rodLength;
			}

			//Construct contact
			Particle2DContact contact = new Particle2DContact();
			contact.mObj1 = mObj1;
			contact.mObj2 = mObj2;
			contact.mContactNormal = diff;
			contact.mRestitutionCo = mRestitution;
			contact.mPenetration = mPenetration;
			contact.mMove1 = new Vector3();
			contact.mMove2 = new Vector3();

			ContactResolver.addParticleContact(contact);
		}

	}
}
