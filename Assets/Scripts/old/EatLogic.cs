using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EatLogic : MonoBehaviour
{
    private Tilemap clayTilemap;
    private Tilemap mushroomTilemap;

    private GameObject grid;

    private Transform slimeTransform;

    [SerializeField]private bool AllowEatClay;

    [SerializeField]private AudioSource soundEat;

    void Awake() {
        grid = GameObject.Find("grid");
        clayTilemap=GameObject.Find("clay").GetComponent<Tilemap>();
        mushroomTilemap=GameObject.Find("mushroom").GetComponent<Tilemap>();
        slimeTransform=GetComponent<Transform>();
        // Подсчёт всех грибов на уровне
        int sumOfMushrooms=0;
        for(int x=mushroomTilemap.cellBounds.x;x<=mushroomTilemap.size.x;x++){
            for(int y=mushroomTilemap.cellBounds.y;y<=mushroomTilemap.size.y;y++){
                if(mushroomTilemap.GetTile(new Vector3Int(x,y,0))!=null){
                    sumOfMushrooms+=1;
                }
            }
        }        
        
        if(SlimeData.SumMushroomOnLevel.Count<=SlimeData.NumberOfLevel){
            SlimeData.SumMushroomOnLevel.Add(sumOfMushrooms);
        }else{
            SlimeData.SumMushroomOnLevel.Insert((int) SlimeData.NumberOfLevel,sumOfMushrooms);
        }
    }

    void Start()
    {
        

        


    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Clay")){
            Vector3 colPosition = Vector3.zero;
            foreach(ContactPoint2D col in collision.contacts){
                // Смещение для точного вычисления нахождения блока
                colPosition.x = col.point.x - 0.01f * col.normal.x;
                colPosition.y = col.point.y - 0.01f * col.normal.y;
                if(clayTilemap.GetTile(clayTilemap.WorldToCell(colPosition))!=null&&AllowEatClay){
                    clayTilemap.SetTile(clayTilemap.WorldToCell(colPosition),null);
                    EatClay();                  
                }
                else if(clayTilemap.GetTile(clayTilemap.WorldToCell(colPosition))==null){
                    continue;
                }
            }
        }
        // //Реализвция для твёрдых грибов
        // if(collision.gameObject.CompareTag("Mushroom")){
        //     Vector3 colPosition=Vector3.zero;
        //     foreach(ContactPoint2D col in collision.contacts){
        //         colPosition.x=col.point.x-0.01f*col.normal.x;
        //         colPosition.y=col.point.y-0.01f*col.normal.y;
        //         if(mushroomTilemap.GetTile(mushroomTilemap.WorldToCell(colPosition))!=null){
        //             mushroomTilemap.SetTile(mushroomTilemap.WorldToCell(colPosition),null);
        //             EatMushroom();           
        //         }
        //         else if(mushroomTilemap.GetTile(mushroomTilemap.WorldToCell(colPosition))==null){
        //             continue;
        //         }
        //     }
        // }


    }

    private void OnTriggerEnter2D(Collider2D collider) {
        // Реализация для не твёрдых грибов
        if (collider.CompareTag("Mushroom")){
            Vector3 colPosition=Vector3.zero;
            Vector2 col;
            col = collider.ClosestPoint(new Vector2(slimeTransform.position.x,slimeTransform.position.y));
            colPosition.x = col.x;
            colPosition.y = col.y;
            if(mushroomTilemap.GetTile(mushroomTilemap.WorldToCell(colPosition))!=null){
                EatMushroom(mushroomTilemap.GetTile(mushroomTilemap.WorldToCell(colPosition)));
                mushroomTilemap.SetTile(mushroomTilemap.WorldToCell(colPosition),null);
                    
            }
        }

    }

    private void EatClay(){
        soundEat.Play();
    }
    private void EatMushroom(TileBase mushroom){
        soundEat.Play();
        if(SlimeData.SumEatMushroomOnLevel.Count<=SlimeData.NumberOfLevel){
            SlimeData.SumEatMushroomOnLevel.Add(0);
        }
        SlimeData.SumEatMushroomOnLevel[SlimeData.NumberOfLevel]=(int)SlimeData.SumEatMushroomOnLevel[SlimeData.NumberOfLevel]+1;
        // SlimeData.SumEatMushroomOnLevel.Insert((int) SlimeData.NumberOfLevel,((int) SlimeData.SumEatMushroomOnLevel[SlimeData.NumberOfLevel])+1);

        
        
        
        if(SlimeData.SumTypesOfEatMushroomOnLevel.Count<=SlimeData.NumberOfLevel){
            SlimeData.SumTypesOfEatMushroomOnLevel.Add(new Dictionary<string, int>());
        }

        Dictionary<string, int> tempMushDict=(Dictionary<string, int>)SlimeData.SumTypesOfEatMushroomOnLevel[SlimeData.NumberOfLevel];

        if(tempMushDict.ContainsKey(mushroom.name)){
            tempMushDict[mushroom.name]+=1;
        }else{
            tempMushDict.Add(mushroom.name,1);
        }



        SlimeData.SumTypesOfEatMushroomOnLevel[SlimeData.NumberOfLevel]=tempMushDict;

    }
}
