using System.Collections.Generic;
using QuikGraph;

namespace Programacion3.Algoritmos
{
    public static class AlgoritmosBusqueda
    {
        public static HashSet<string> BreadthFirstSearch(UndirectedGraph<string, Edge<string>> grafo, string nodoInicial)
        {
            // Creo un HashSet para ir marcando los nodos visitados y lo inicializo con el nodo inicial
            // (para que no se agregue a la cola por segunda vez)
            var nodosVisitados = new HashSet<string> { nodoInicial };
            
            // Creo una cola con nodos a revisar y agrego al nodo inicial para que empiece por el 
            var cola = new Queue<string>();
            cola.Enqueue(nodoInicial);

            while (cola.Count > 0)
            {
                // Obtengo el primer item de la cola
                var actual = cola.Dequeue();
                
                // Hago un loop por cada vecino del nodo actual
                foreach (var vecino in grafo.AdjacentVertices(actual))
                {
                    // Me fijo que no lo haya visitado anteriormente
                    if (!nodosVisitados.Contains(vecino))
                    {
                        // Si querria saber si desde el nodeInicial se podria llegar aun nodoFinal
                        // if (vecino == nodoFinal) return true;
                        
                        // Marco como visitado el nodo para no volver a agregarlo a la cola
                        nodosVisitados.Add(vecino);

                        // Lo agrego a la cola para revisar a los vecinos de este nodo (los vecinos de este vecino)
                        cola.Enqueue(vecino);
                    }
                }
            }
            
            return nodosVisitados;
        }
    }
}