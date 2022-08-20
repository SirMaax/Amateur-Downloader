using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("Info")] public bool gen = false;

    [Header("Color")] 
    public Color backgroundColor;
    public Color textColor;
    public Color iconColor;

    
    [Header("Size")] 
    [Range(0, 3)] public int size;
    public Vector2[] colliderSize;
    
    [Header("Animation")] 
    [Range(0, 2)] public int animation; // 0 is none , 1 is lines 2 is up and down

    [Header("Text")]
    public float xoffset;
    [Range(0, 7)] public int text; //0 is no text
    public bool left = false;

    [Header("Symbol")] 
    public float iconOffset;
    [Range(0, 5)] public int symbol; //0 is no sym
    
    [Header("Refs")]
    public GameObject firstChild;
    public GameObject secondChild;
    public Sprite[] background;
    public Sprite[] texts;
    public Sprite[] symbols;
    public GameObject popUpFab;

    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        gen = true;
        SetSize();
        gameObject.transform.localScale = new Vector3(4.19f, 4.19f, 4.19f);
        // transform.localScale = new Vector3(4.19f, 4.19f, 4.19f);
        // secondChild.transform.localScale = new Vector3(4.19f, 4.19f, 4.19f);
        // firstChild.transform.localScale = new Vector3(4.19f, 4.19f, 4.19f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gen)
        {
            gen = false;
            StartCoroutine(CoolDown());
            SetSize();
        }
        
    }

    private void SetSize()
    {
        SetColliderSize();
        firstChild.transform.position = transform.position;
        secondChild.transform.position = transform.position;
        Animator.enabled = false;
        secondChild.GetComponent<SpriteRenderer>().sprite = null;
        firstChild.GetComponent<SpriteRenderer>().sprite = null;


        GetComponent<SpriteRenderer>().sprite = background[size];

        if (symbol != 0)
        {
            if (text == 0)
            {
                secondChild.GetComponent<SpriteRenderer>().sprite = symbols[symbol-1];
            }
            else
            {
                //text with symbol
                if (text != 0)
                {
                    if (left)
                    {
                        firstChild.GetComponent<SpriteRenderer>().sprite = texts[text-1];
                        Vector3 pos = new Vector3(xoffset, 0, 0);
                        firstChild.transform.position += pos;
                        secondChild.GetComponent<SpriteRenderer>().sprite = symbols[symbol-1];
                        pos = new Vector3(iconOffset, 0, 0);
                        secondChild.transform.position -= pos; 
                    }
                    else
                    {
                        firstChild.GetComponent<SpriteRenderer>().sprite = texts[text-1];
                        Vector3 pos = new Vector3(xoffset, 0, 0);
                        firstChild.transform.position -= pos;
                        secondChild.GetComponent<SpriteRenderer>().sprite = symbols[symbol-1];
                        pos = new Vector3(iconOffset, 0, 0);
                        secondChild.transform.position += pos; 
                    }
                    

                }
            }
        }
        
        if (text != 0 && symbol == 0)
        {
            firstChild.GetComponent<SpriteRenderer>().sprite = texts[text-1];
        }



        if (animation == 1)
        {
            if(size==0)Animator.Play("B_S");
            if(size==1)Animator.Play("B_M");
            if(size==2)Animator.Play("B_L");
            if(size==3)Animator.Play("B_XL");
            Animator.enabled = true;
        }else if (animation == 2)
        {
            if(size==0)Animator.Play("B_S_2");
            if(size==1)Animator.Play("B_M_2");
            if(size==2)Animator.Play("B_L_2");
            if(size==3)Animator.Play("B_XL_2");
            Animator.enabled = true;

        }
        else
        {
            if (size == 0)Animator.enabled = false;
        }

        GetComponent<SpriteRenderer>().color = backgroundColor;
        firstChild.GetComponent<SpriteRenderer>().color = textColor;
        secondChild.GetComponent<SpriteRenderer>().color = iconColor;

        
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.1f);
        gen = true;
    }

    private void SetColliderSize()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();

        collider2D.size = colliderSize[this.size];
    }
}
