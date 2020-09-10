using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    #region Singltone
    public static LevelManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    public List<GameObject> FoodForCat { get => foodForCat; set => foodForCat = value; }
    [SerializeField] List<GameObject> foodForCat = new List<GameObject>();
    [SerializeField] List<Transform> CatPoints = new List<Transform>();
    public Transform Player;

    private void OnDrawGizmosSelected()
    {
        foreach (var item in CatPoints)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(item.position, item.position + new Vector3(0, 2, 0));
        }
    }
    public void AddFoot(GameObject gameObject)
    {
        foodForCat.Add(gameObject);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
