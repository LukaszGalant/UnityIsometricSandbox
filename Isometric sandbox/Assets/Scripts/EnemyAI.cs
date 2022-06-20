using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static TagManager;
using UnityEngine.AI;



class AggroTable
{
    public GameObject Ally { get; set; }
    public float Points { get; set; }
}




public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public float SightRadius = 10f;
    List<AggroTable> AggroTable;
    RaycastHit hit;
    public float TheHighestAggro;



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SightRadius);
    }

    // Start is called before the first frame update
    void Start()
    {
        AggroTable = new List<AggroTable>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        //TagManager.TestActionAddingDamage += AddAggroDamage; // TO BE REMOVED AFTER TESTS!!!
    }

    // Update is called once per frame
    void Update()
    {








        foreach (var AllyGameObject in ListOfAllies) //for each object with tag "Ally"
        {
            if (!AggroTable.Any(obj => obj.Ally == AllyGameObject)) //if table AggroTable do not contain this "Ally" object
            {
                float distance = Vector3.Distance(AllyGameObject.transform.position, transform.position); //if distance between objects is too large
                if (distance <= SightRadius)
                {
                    if (Physics.Raycast(transform.position, (AllyGameObject.transform.position - transform.position), out hit, SightRadius)) //if ray hits
                    {
                        if (hit.transform == AllyGameObject.transform) //if ray hits the "Ally" object
                        {
                            Debug.Log("Added: " + AllyGameObject.name);
                            AggroTable.Add(new AggroTable() { Ally = AllyGameObject, Points = 0 }); //add to AggroTable
                        }
                    }
                }
            }
        }




        if (AggroTable.Count != 0)
        {
            //find the higest aggro points in AggroTable
            foreach (var v in AggroTable)
            {
                if (v.Points > TheHighestAggro)
                    TheHighestAggro = v.Points;
            }

            //find who has the most aggro points in AggroTable (if the are duplicates, choose first from top)
            AggroTable result = AggroTable.Find(delegate (AggroTable AggroTable)
            {
                return AggroTable.Points == TheHighestAggro;
            }
            );


            foreach (var AllyGameObject in ListOfAllies)
            {
                if (AllyGameObject == result.Ally)
                {
                    //can I see him?
                    if (Physics.Raycast(transform.position, (AllyGameObject.transform.position - transform.position), out hit, SightRadius)) 
                    {
                        if (hit.transform == AllyGameObject.transform) //if ray hits the "Ally" object
                        {
                            //follow
                            navMeshAgent.SetDestination(AllyGameObject.transform.position);
                        }
                        else
                        {
                            var itemToRemove = AggroTable.Single(r => r.Ally == AllyGameObject);
                            AggroTable.Remove(itemToRemove);
                            Debug.Log("Removed " + AllyGameObject.name + " from AggroList; stopped following. Looking for new follow");
                            navMeshAgent.SetDestination(transform.position);
                        }    
                    }
                }
            }
        }
        else
        {
            TheHighestAggro = -1;
        }

    }

    public void AddAggroDamage(GameObject Ally) // TO BE FIXED AFTER TESTS!!!
    {
        float Points = 1;
        foreach (var a in AggroTable)
        {
            if (a.Ally == Ally)
            {
                a.Points += Points;
            }
        }
    }



}
