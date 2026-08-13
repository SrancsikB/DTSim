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

    public int wear = 0;
    public bool fail= false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RobotController robot =GetComponent<RobotController>();
        PaletteController pal = collision.GetComponent<PaletteController>();
        SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
        SpriteRenderer robotsr=GetComponent<SpriteRenderer>();
       
        if (robot.gameObject.name=="Robot")
        {
            
            if (pal != null)
            {
                Debug.Log("Paletta elérve");
                if (spriteRenderer != null)
                {
                    if (Random.Range(70,101)<wear)
                    {
                        fail = true;
                        robotsr.color = Color.red;
                        Color color = robotsr.color;
                        color.a = 0.65f;
                        robotsr.color = color;
                        robotsr.sortingOrder = 3;
                        return;
                    }
                    if (spriteRenderer.color==Color.white && !fail)
                    {
                        int chance = Random.Range(1, 101);
                        if (chance > 95)
                        {
                            return;
                        }
                        else if (chance>75)
                        {
                            spriteRenderer.color = Color.red;
                            spriteRenderer.sortingOrder = 1;
                            wear += 2;
                            return;
                        }

                        spriteRenderer.color = Color.green;
                        wear += 2;
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
                        
                        Debug.Log("Nincs kiszinezve!");
                        return;
                    }
                    if (spriteRenderer.color == Color.red)
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
                    if (Random.Range(70,101)<wear)
                    {
                        fail = true;
                        robotsr.color = Color.red;
                        Color color = robotsr.color;
                        color.a = 0.65f;
                        robotsr.color = color;
                        robotsr.sortingOrder = 3;
                        return;
                    }
                    if (spriteRenderer.color != Color.green && !fail)
                    {
                        spriteRenderer.color = Color.green;
                        Debug.Log("Hiba javítva!");
                        wear += 10;
                        return;
                    }
                    
                }
            }
        }


    }

    private void OnMouseDown()
    {
        if (fail==true)
        {
            fail = false;
            wear = 0;
            SpriteRenderer robotsr = GetComponent<SpriteRenderer>();
            robotsr.color = Color.grey;
            Color color=robotsr.color;
            color.a = 0.65f;
            robotsr.color = color;
            robotsr.sortingOrder = -1;
            
        }
    }
}
