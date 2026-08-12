using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RobotController robot =GetComponent<RobotController>();
        PaletteController pal = collision.GetComponent<PaletteController>();
        SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
        if (robot.gameObject.name=="Robot")
        {
            
            if (pal != null)
            {
                Debug.Log("Paletta elérve");
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Random.Range(1, 101) > 75 ? Color.red : Color.green;
                    if (spriteRenderer.color==Color.green)
                    {
                        spriteRenderer.color = Random.Range(1, 101) > 75 ? Color.white : Color.green;
                        
                    }
                    return;

                }
            }
        }

        if (robot.gameObject.name=="Tester")
        {
            if (pal!=null)
            {
                if (spriteRenderer!=null)
                {
                    if(spriteRenderer.color==Color.white) 
                    {
                        pal.oneOrTwo = 2;
                        Debug.Log("Nincs kiszinezve!");
                        return;
                    }
                    if (pal.oneOrTwo==2)
                    {
                        Debug.Log("Hibás szín találva!");
                        return;
                    }
                    
                }
            }
        }

        if (robot.gameObject.name == "Fixer")
        {
            if (pal != null)
            {
                if (spriteRenderer != null)
                {
                    if (pal.oneOrTwo == 2)
                    {
                        spriteRenderer.color = Color.green;
                        pal.oneOrTwo = 1;
                        Debug.Log("Hiba javítva!");
                        return;
                    }
                    
                }
            }
        }


    }
}
