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
        PaletteController pal = collision.GetComponent<PaletteController>();
        SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
        if (pal != null)
        {
            Debug.Log("Paletta elérve");
            if (spriteRenderer != null)
            {
                if (pal.oneOrTwo==2)
                {
                    spriteRenderer.color = Color.red;
                }
                
            }
        }
        
        
    }
}
