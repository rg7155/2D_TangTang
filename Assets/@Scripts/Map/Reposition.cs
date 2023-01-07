using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class Reposition : MonoBehaviour
{

    Collider2D collider; //콜라이더 부모
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

        
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        var playerPos = Managers.Object.Player.transform.position;
        Vector3 playerDir = Managers.Object.Player.inputVector;
        var myPos = transform.position;
       
        switch(transform.tag)
        {
            case "Ground":
                float fX = Mathf.Abs(playerPos.x - myPos.x), fY = Mathf.Abs(playerPos.y - myPos.y); float dirX = (playerPos.x > myPos.x) ? 1 : -1, dirY = (playerPos.y > myPos.y) ? 1 : -1;
                if (fX > fY)
                    transform.Translate(Vector2.right * TILEMAP_SIZE * dirX); //맵 반지름 40
                else
                    transform.Translate(Vector2.up * TILEMAP_SIZE * dirY);
                break;
            case "Monster":
                if(collider.enabled)
                    transform.Translate(playerDir * (TILEMAP_SIZE >> 1) + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0));
                break;
        }



    }
}

