using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArray : MonoBehaviour
{
    // Variable p�blica para asignar el prefab desde el Inspector
    public GameObject blockPrefab;

    // Variables p�blicas para definir las dimensiones del muro
    public int N = 3; // Cantidad de bloques en el eje X
    public int M = 4; // Cantidad de bloques en el eje Y

    // Tama�o del bloque (si no se puede obtener del Renderer)
    public Vector3 blockSize = new Vector3(1, 1, 1); // Ajusta el tama�o seg�n sea necesario

    void Start()
    {
        if (blockPrefab == null)
        {
            Debug.LogError("El prefab del bloque no est� asignado.");
            return;
        }

        // Comprobar si el prefab tiene un Renderer
        Renderer renderer = blockPrefab.GetComponent<Renderer>();
        if (renderer != null)
        {
            blockSize = renderer.bounds.size; // Si tiene Renderer, usamos el tama�o del prefab
        }

        // Crear el muro usando bucles anidados
        for (int i = 0; i < N; i++) // Para el eje X
        {
            for (int j = 0; j < M; j++) // Para el eje Y
            {
                // Calcular la posici�n del bloque
                Vector3 position = new Vector3(i * blockSize.x, j * blockSize.y, 0);

                // Instanciar el bloque en la posici�n calculada
                Instantiate(blockPrefab, position, Quaternion.identity);
            }
        }
    }
}
