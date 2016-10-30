using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{
    public float posMinIzq;
    public float posMinDer;
    public float speed = 15, jumpVelocity = 40;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    //Transform myTrans, tagGround;
    Rigidbody2D myBody;
    public bool isGrounded = false;
    float hInput = 0;

    public string lado = "";


    public Transform compSuelo;
    float comprobadorRadio = 0.03f;
    public LayerMask mascaraSuelo;

    #region Funcionalidad desde GameManager
    //controlar la textura del player
    public Texture playerHealthTexture;
    //variables 
    public float screenPositionX;
    public float screenPositionY;
    public float iconSizeX = 25;
    public float iconSizeY = 25;
    //iniciara con 3 health
    public int playerHealth = 5;
    #endregion


    //PARA EL MOVIL

    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject CanvasInventario;
    SlotInventario slotInventario;
    //PARA EL MOVIL


    //daño que tomara el player
    float takenDamage = 0.2f;


    //takendamage
    //float takenDamage = 0.2f;

    #region Barra de Hidratacion
    public RectTransform HidroTransform;
    private float almacenadaY;
    private float minXValue;
    private float maxXValue;
    private int hidratacionActual;
    public int MaxHidratacion;
    #endregion

    #region Sound Effects
    public AudioSource salto;
    public AudioSource aterrizar;
    public AudioSource pisada1;
    public AudioSource pisada2;
    public AudioSource Disparo;
    #endregion


    void Start()
    {
        Time.timeScale = 1f;
        #region Barra de Hidratación
        //StartCoroutine(DescHidratacion());
        #endregion
        //armas inactivas al empezar
        bullet1.SetActive(false);
        bullet2.SetActive(false);

        #region Barra de Hidratacion
        almacenadaY = HidroTransform.position.y;
        maxXValue = HidroTransform.position.x;
        minXValue = HidroTransform.position.x - HidroTransform.rect.width;
        setHidratacionActual(MaxHidratacion);
        #endregion

        myBody = this.GetComponent<Rigidbody2D>();
        //myTrans = this.GetComponent<Transform>();
        //myTrans = this.transform;
        //tagGround = GameObject.Find (this.name + "tag_ground").transform;

        // en android el inventario comienza inactivo
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR

        CanvasInventario.active = false;
#else
		Move (hInput);
#endif
    }


    void FixedUpdate()
    {
        //MobileDisparo();

        if (Input.GetButton("Horizontal"))
        {
            if (isGrounded)
            {
                if (!pisada1.isPlaying)
                {
                    pisada1.Play();

                }
                else if (!pisada2.isPlaying)
                {
                    pisada2.Play();
                }
            }

        }

        if (transform.position.x <= posMinIzq)
        {
            Debug.Log("Aquí debías parar");
        }

        if (transform.position.x >= posMinDer)
        {
            Debug.Log("Aquí debías parar");
        }


        //isGrounded = Physics2D.Linecast (myTrans.position, tagGround.position, playerMask);
        isGrounded = Physics2D.OverlapCircle(compSuelo.position, comprobadorRadio, mascaraSuelo);





        //LLAMA AL METODO CLICK DE SLOTINVENTARIO
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        //Move();
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("click"))
            slotInventario.click();

#else
		Move (hInput);
#endif
        // PARA MOVER EL MARCADOR, SE LLAMA AL MEDOTO DEL SCRIPT SLOTINVENTARIO
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        //Move();
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("marcadore"))
            slotInventario.marcadore();
#else
		Move (hInput);
#endif

        // PARA ABRIR EL INVENTARIO
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        //Move();
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("abrirInventario"))
            abrirInventario();

#else
		Move (hInput);
#endif
    }

    private void MobileDisparo()
    {
        //if (Input.GetKeyDown(KeyCode.F) || Input.GetButton(""))
        BulletAttack();
    }

    //if(Input.GetButtonDown("CambiarArma"))}
    //cambiarArma();









    void Update()
    {
        #region Barra de Hidratacion
        StartCoroutine(DescHidratacion());
        //if (hidratacionActual >= 0)
        //{
        //HidratacionActual = (int)(HidratacionActual - (1 * Time.deltaTime));
        //    setHidratacionActual((int)(getHidratacionActual() - (0.05f * Time.deltaTime)));
        //}
        #endregion
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        //Move();
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
            Jump();
#else
		Move (hInput);
#endif
    }

    IEnumerator DescHidratacion()
    {
        yield return new WaitForSeconds(3);
        if (hidratacionActual >= 0)
        {
            //HidratacionActual = (int)(HidratacionActual - (1 * Time.deltaTime));
            setHidratacionActual((int)(getHidratacionActual() - (0.02f * Time.deltaTime)));
        }
    }

    public void moveDer()
    {
        transform.Translate(Vector2.right * 4f * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, 0);
        lado = "derecha";
    }

    public void moveIzq()
    {
        transform.Translate(Vector2.right * 4f * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, 180);
        lado = "izquierda";
    }

    public void Move(float horizontalInput)
    {
        if (Input.GetKey(KeyCode.RightArrow) || horizontalInput == 1)
        {
            if (!canMoveInAir && !isGrounded)
                return;
            if (!(transform.position.x >= posMinDer))
            {
                moveDer();
            }


        }

        if (Input.GetKey(KeyCode.LeftArrow) || horizontalInput == -1)
        {
            if (!canMoveInAir && !isGrounded)
                return;
            if (!(transform.position.x <= posMinIzq))
            {
                moveIzq();
            }

        }
    }
    //public void Move(float horizonalInput)
    //{
    //    if (!canMoveInAir && !isGrounded)
    //        return;

    //    Vector2 moveVel = myBody.velocity;
    //    moveVel.x = horizonalInput * speed;
    //    myBody.velocity = moveVel;
    //}

    public void Jump()
    {
        if (isGrounded)
        {
            myBody.velocity += jumpVelocity * Vector2.up;
            salto.Play();
        }
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;
    }

    //METODOS PARA EL MOVIL

    //abrir inventario
    public void abrirInventario()
    {
        CanvasInventario.active = !CanvasInventario.active;
    }





    // para el DAÑO AL JUGADOR
    public IEnumerator TakenDamage()
    {
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(takenDamage);
    }






    #region Barra de Hidratacion	
    private void ManejoHidratacion()
    {
        float ValorXActual = MapeoValores(getHidratacionActual(), 0, MaxHidratacion, minXValue, maxXValue);
        HidroTransform.position = new Vector2(ValorXActual, almacenadaY);
    }

    private float MapeoValores(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    /*private int HidratacionActual{
		get { return HidratacionActual;}
		set { 
			HidratacionActual = value;
			ManejoHidratacion ();
		}
	}*/

    private void setHidratacionActual(int value)
    {
        hidratacionActual = value;
        ManejoHidratacion();
    }
    private int getHidratacionActual()
    {
        return hidratacionActual;
    }
    #endregion



    // DESTRUIR HELADO SI COLISIONA CON EL
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Helado")
        {

            Destroy(col.gameObject);

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Soil")
        {
            aterrizar.Play();
        }
    }

    public void BulletAttack()
    {

        if (bullet1.activeSelf)
        {
            if (lado.Equals("derecha"))
            {
                GameObject bPrefab = Instantiate(bullet1, transform.position, Quaternion.identity) as GameObject;
                bPrefab.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 900);
                Disparo.Play();
            }
            else if (lado.Equals("izquierda"))
            {
                GameObject bPrefab = Instantiate(bullet1, transform.position, Quaternion.identity) as GameObject;
                bPrefab.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 900);
                Disparo.Play();
            }


        }
        else if (bullet2.activeSelf)
        {

            if (lado.Equals("derecha"))
            {
                GameObject bPrefab = Instantiate(bullet2, transform.position, Quaternion.identity) as GameObject;
                bPrefab.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 900);
                Disparo.Play();
            }
            else if (lado.Equals("izquierda"))
            {
                GameObject bPrefab = Instantiate(bullet2, transform.position, Quaternion.identity) as GameObject;
                bPrefab.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 900);
                Disparo.Play();
            }
        }
    }

    #region Funcionalidad de GameManager
    //para quitar health o agregar health
    void OnGUI()
    {
        for (int h = 0; h < playerHealth; h++)
        {
            GUI.DrawTexture(new Rect(screenPositionX + (h * iconSizeX), screenPositionY, iconSizeX, iconSizeY), playerHealthTexture, ScaleMode.ScaleToFit, true, 0);
        }
    }
    //METODO PARA QUITAR VIDAS 
    void PlayerDamaged()
    {
        if (playerHealth > 0)
        {
            playerHealth--;
        }

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            RestartScene();
        }
    }
    //reinicia la escena
    void RestartScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    //METODO QUE AUMENTA VIDA (como maximo 5)

    void PlayerVida()
    {
        if (playerHealth < 5)
        {
            playerHealth++;
        }
    }
    #endregion
}

