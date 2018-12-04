using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour {
 public Transform[] nodes;
       private int nodeCount;
       public int nearstnode;
 
 
       // Use this for initialization
       private void Start () {
 
           nodeCount = transform.childCount;
           nodes = new Transform[nodeCount];
 
           for (int i = 0; i < nodeCount ; i++) {
               nodes [i] = transform.GetChild (i);
           }
 
       }
     
       // Update is called once per frame
       private void Update () {
           if (nodeCount > 1) {
               for (int i = 0; i < nodeCount - 1; i++) {
                   Debug.DrawLine (nodes[i].position, nodes[i+1].position, Color.green);
               }
           }
       }
 
       public Vector3 ProjectPositionOnRail(Vector3 pos){
           int ClosestNodeIndex = GetClosestNode(pos);
           if (ClosestNodeIndex == 0) {
               return ProjectOnSegment (nodes [0].position, nodes [1].position, pos);
           } else if (ClosestNodeIndex == nodeCount - 1) {
               return ProjectOnSegment (nodes [nodeCount-1].position, nodes [nodeCount-2].position, pos);
           } else {
               Vector3 LeftSeg = ProjectOnSegment (nodes [ClosestNodeIndex - 1].position , nodes [ClosestNodeIndex].position, pos);
               Vector3 RightSeg = ProjectOnSegment (nodes [ClosestNodeIndex + 1].position, nodes [ClosestNodeIndex].position, pos);
               Debug.DrawLine (pos, LeftSeg, Color.red);
               Debug.DrawLine (pos, RightSeg, Color.blue);
 
               if ((pos - LeftSeg).sqrMagnitude <= (pos - RightSeg).sqrMagnitude) {
                   return LeftSeg;
               } else {
                   return RightSeg;
               }
           }
       }
 
       private int GetClosestNode(Vector3 pos){
           int ClosestNodeIndex = -1;
           float ShortestDistance = 0.0f;
           for (int i = 0; i < nodeCount; i++) {
               float sqrDistance = (nodes [i].position - pos).sqrMagnitude;
               if (ShortestDistance == 0.0f || sqrDistance < ShortestDistance) {
                   ShortestDistance = sqrDistance;
                   ClosestNodeIndex = i;
               }
           }
           nearstnode = ClosestNodeIndex;
           return ClosestNodeIndex;
       }
 
       public Vector3 ProjectOnSegment(Vector3 v1, Vector3 v2, Vector3 pos){
           Vector3 v1ToPos = pos - v1;
           Vector3 segDirection = (v2 - v1).normalized;
           float DistanceFromV1 = Vector3.Dot (segDirection, v1ToPos);
           if (DistanceFromV1 < 0.0f) {
               return v1;
           } else if (DistanceFromV1 * DistanceFromV1 > (v2 - v1).sqrMagnitude) {
               return v2;
           } else {
               Vector3 fromV1 = segDirection * DistanceFromV1;
               return v1 + fromV1;
           }
       
	   }}
	   