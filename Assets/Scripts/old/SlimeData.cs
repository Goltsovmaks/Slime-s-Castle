using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeData : MonoBehaviour
{
    public static string currentLevel=null;
    public static ArrayList FinishedLevelTime = new ArrayList();
    public static int NumberOfLevel;
    public static List<Vector3> PointOfResurrect=new List<Vector3>();

    public static ArrayList SumEatMushroomOnLevel = new ArrayList(){0,0,0,0,0,0};
    public static ArrayList SumMushroomOnLevel = new ArrayList(){0,0,0,0,0,0};

    // Dictionary<string, int> SumTypesOfEatMushroomOnLevel = new Dictionary<string, int>();

    public static ArrayList SumTypesOfEatMushroomOnLevel = new ArrayList(){new Dictionary<string, int>()};
    void Start()
    {
        SumEatMushroomOnLevel.Add(0);
        SlimeData.currentLevel=SceneManager.GetActiveScene().name;
        switch(SlimeData.currentLevel){
            case "trainLevel":
            NumberOfLevel=0;
            break;

            case "levelSt1":
            NumberOfLevel=1;
            break;
            case "levelSt2":
            NumberOfLevel=2;
            break;
            case "SyrioLevel":
            NumberOfLevel=3;
            break;
            case "Level3":
            NumberOfLevel=4;
            break;
            case "Level4":
            NumberOfLevel=5;
            break;

        }
        
    }

// List<Vector3> tpPos = new List<Vector3>();

    // Start is called before the first frame update
    // void Start()
    // {
    //     print(FinishedLevelTime.Count +"+");
        
    //     // if(FinishedLevelTime.)
        
    // }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

    // Функционал для поиска неактивных объектов иерархии
    public static class GameObjectExtension {
        public static Object Find(string name, System.Type type) {
            Object[] objects = Resources.FindObjectsOfTypeAll(type);
            foreach(var obj in objects) {
                if(obj.name == name) {
                    return obj; 
                }
            }
            return null;
        }

        public static GameObject Find(string name) {
            return Find(name, typeof(GameObject)) as GameObject;
        }
    }
}
