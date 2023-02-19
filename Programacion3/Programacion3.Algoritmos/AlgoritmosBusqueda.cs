using Microsoft.VisualStudio.GraphModel;
using System.Collections.Generic;

namespace Programacion3.Algoritmos
{
    public static class AlgoritmosBusqueda
    {
        public static HashSet<GraphNode> BreadthFirstSearch(GraphNode nodoInicial)
        {
            // Creo un HashSet para ir marcando los nodos visitados y lo inicializo con el nodo inicial
            // (para que no se agregue a la cola por segunda vez)
            var nodosVisitados = new HashSet<GraphNode> { nodoInicial };
            
            // Creo una cola con nodos a revisar y agrego al nodo inicial para que empiece por el 
            var cola = new Queue<GraphNode>();
            cola.Enqueue(nodoInicial);

            while (cola.Count > 0)
            {
                // Obtengo el primer item de la cola
                var actual = cola.Dequeue();
                
                // Hago un loop por cada vecino del nodo actual
                foreach (var vecino in actual.AllLinks.AsNodes())
                {
                    // Me fijo que no lo haya visitado anteriormente
                    if (!nodosVisitados.Contains(vecino))
                    {
                        // Si querria buscar el camino mas corto a un nodoFinal
                        // if (vecino == nodoFinal) return nodosVisitados;
                        
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