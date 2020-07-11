//JOSÉ PABLO PEÑALOZA
//Script que maneja una pool para el spawn the objetos.
//cui honorem, honorem honorem -> https://www.youtube.com/watch?v=tdSmKaJvCoA
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable] //Habilita que esté en el inspector y es editable
    public class Pool //Clase del pool
    {
        public string tag; //Nombre (para identificarlos)
        public GameObject prefab;  
        public int size;          
    }

    public static ObjectPooler Instance; 

    public List<Pool> pools; //List que permite añadir las pools desde el inspector
    public Dictionary<string, Queue<GameObject>> poolDictionary; //Se crea el diccionario que guarda las listas

    private void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>(); //Se inicializa el diccionario
        foreach (Pool pool in pools)//Recorremos la lista de pool para añadirla al diccionario
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)//Instanciamos todos los objetos del pool
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool); //Añadimos al diccionario la lista de gameobjects
        }
    }

    public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag)) //Checa que la tag sea válida
        {
            Debug.LogWarning("NO existe el tag " + tag + "en la pool");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue(); //Saca un objeto de la fila del pool indicada

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation; //Coloca al objeto en la escena 

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();//SE llama a la interfaz que se ejecuta con todo objeto creado
        if(pooledObj != null)
        {
            pooledObj.onObjectSpawn(); //Se mete a la interfaz del objeto
        }

        poolDictionary[tag].Enqueue(objectToSpawn); //Regresa a otro objeto a la lista 
        return objectToSpawn;
    }
    
}
