using System.ComponentModel;
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
                    spriteRenderer.color=Random.Range(1, 101)>75 ? Color.red : Color.green;
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
                    pal.oneOrTwo=spriteRenderer.color == Color.red ? 2 : 1;
                    if (pal.oneOrTwo==2)
                    {
                        Debug.Log("Hiba találva!");
                    }
                    return;
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
                    }
                    return;
                }
            }
        }


    }
}
