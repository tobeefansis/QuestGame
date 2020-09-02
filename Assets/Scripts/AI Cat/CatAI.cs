using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class CatAI : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent agent;
    public GameObject target;

    List<GameObject> FoodForCat;

    public NavMeshAgent Agent { get => agent; set => agent = value; }


    // Start is called before the first frame update
    void Start()
    {
        FoodForCat = LevelManager.instance.FoodForCat;
    }

    // Update is called once per frame
    void Update()
    {
        if (FoodForCat.Count > 0)
        {
            var tempTarget = FoodForCat[0];
            foreach (var item in FoodForCat)
            {
                if (Vector3.Distance(item.transform.position, transform.position) < Vector3.Distance(tempTarget.transform.position, transform.position))
                {
                    tempTarget = item;
                }
            }
            target = tempTarget;
            animator.SetFloat("Distance To Food", Vector3.Distance(tempTarget.transform.position, transform.position));
        }
        else
        {
            target = null;
            animator.SetFloat("Distance To Food", 100);
        }
    }
}
