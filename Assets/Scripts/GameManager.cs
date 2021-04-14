using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; //Definimos la instancia del game manager. Paso imprescindible para el Singleton
    int damage;
    void Awake() //Utilizamos awake en vez de Start para asegurarnos que la UIManager se inicia antes que cualquier otro componente      de la escena
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); //utilizamos este código para mantener el GameManager en todas los escenas pero                  teniéndolo únicamente en la primera
        }
        else Destroy(this.gameObject); //Eliminamos los prefabs que queden restantes
    }
    public static GameManager GetInstance() //Habilitamos la respuesta de instancia para el GameManager
    {
        return instance;
    }
}
