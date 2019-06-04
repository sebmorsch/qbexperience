using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
    public class dbtest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Ich Komme rein");
            QBExperienceDb mLocationDb = new QBExperienceDb();
            //Add Data
            mLocationDb.addData(new RouteEntity("0", "AR", "0.001"));
            mLocationDb.addData(new RouteEntity("1", "AR", "0.002"));
            mLocationDb.addData(new RouteEntity("2", "AR", "0.003"));
   
            mLocationDb.close();
        }
    }
}
