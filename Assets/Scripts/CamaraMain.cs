using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMain : MonoBehaviour {

    public CamaraScript Rail;
       public Transform Player;
       public float MoveSpeed = 5.0f;
       public Transform thisTransform;
       public Vector3 LastPosition;
   
       // Use this for initialization
       private void Start () {
           thisTransform = transform;
           LastPosition = thisTransform.position;
   
       }
   
       // Update is called once per frame
       private void Update () {
   
   
       
           LastPosition = Vector3.Lerp (LastPosition, Rail.ProjectPositionOnRail (Player.position), Time.deltaTime * MoveSpeed);
           thisTransform.position = LastPosition;
   
       }
}
