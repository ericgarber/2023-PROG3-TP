using System.Collections.Generic;
using System.Linq;
using QuikGraph;

namespace Programacion3.Algoritmos
{
    public static class AlgoritmosUtils
    {
        public static string[] BreadthFirstSearch(UndirectedGraph<string, Edge<string>> grafo, string nodoInicial)
        {
            // Creo un array para ir marcando los nodos visitados y lo inicializo con el nodo inicial
            // (para que no se agregue a la cola por segunda vez)
            var nodosVisitados = new[] { nodoInicial };

            // Creo una cola con nodos a revisar y agrego al nodo inicial para que empiece por el 
            var cola = new Queue<string>();
            cola.Enqueue(nodoInicial);

            // Mientras haya nodos en la cola
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
                        // Marco como visitado el nodo para no volver a agregarlo a la cola
                        nodosVisitados = nodosVisitados.Append(vecino).ToArray();

                        // Lo agrego a la cola para revisar a los vecinos de este nodo (los vecinos de este vecino)
                        cola.Enqueue(vecino);
                    }
                }
            }

            return nodosVisitados;
        }

        public static string[] DepthFirstSearch(UndirectedGraph<string, Edge<string>> grafo, string nodoInicial)
        {
            // Creo un array para ir marcando los nodos visitados y lo inicializo con el nodo inicial
            // (para que no se agregue a la pila por segunda vez)
            var nodosVisitados = new string[] {  };

            // Creo una pila con nodos a revisar y agrego al nodo inicial para que empiece por el 
            var pila = new Stack<string>();
            pila.Push(nodoInicial);

            // Mientras haya nodos en la pila
            while (pila.Count > 0)
            {
                // Obtengo el ultimo item agregado a la pila
                var actual = pila.Pop();

                if (nodosVisitados.Contains(actual))
                    continue;

                nodosVisitados = nodosVisitados.Append(actual).ToArray();
                
                // Hago un loop por cada vecino del nodo actual
                foreach (var vecino in grafo.AdjacentVertices(actual).Reverse())
                {
                    // Me fijo que no lo haya visitado anteriormente
                    if (nodosVisitados.Contains(vecino))
                        continue;
                    
                    // Lo agrego a la pila para revisar a los vecinos de este nodo (los vecinos de este vecino)
                    pila.Push(vecino);
                }
            }

            return nodosVisitados;
        }

        public static (Dictionary<string, double> distancias, Dictionary<string, string> padres)
            Dijkstra(BidirectionalGraph<string, TaggedEdge<string, double>> grafo, string nodoInicial)
        {
            var distancias = new Dictionary<string, double>();
            var padres = new Dictionary<string, string>();
            
            var visitados = new HashSet<string>();
            var cantidadNodos = grafo.VertexCount;

            // Inicializar la distancia de todos los nodos como infinita
            foreach (var nodo in grafo.Vertices)
            {
                distancias[nodo] = double.PositiveInfinity;
            }

            // Agrego el nodo inicial con distancia 0
            distancias[nodoInicial] = 0;

            while (visitados.Count < cantidadNodos - 1)
            {
                // Busco el nodo con minima distancia que todavia no haya visitado
                var actual = BuscarNodoConMinimaDistancia(distancias, visitados);

                // Si no se encontro un nodo alcanzable (distancia infinita), salgo del loop
                if (double.IsPositiveInfinity(distancias[actual]))
                    break;

                visitados.Add(actual);

                // Recorrer todos los vecinos del nodo actual
                foreach (var arista in grafo.OutEdges(actual))
                {
                    var vecino = arista.Target;

                    // Salir si el vecino ya fue visitado
                    if (visitados.Contains(vecino))
                        continue;
                    
                    // Sumo el peso de la arista al valor de la distancia del nodo actual
                    var nuevaDistancia = distancias[actual] + arista.Tag;

                    // Si la nueva distancia es menor a la que estaba guardada, la reemplazo por la nueva distancia y guardo el padre
                    if (nuevaDistancia < distancias[vecino])
                    {
                        distancias[vecino] = nuevaDistancia;
                        padres[vecino] = actual;
                    }
                }
            }

            return (distancias, padres);
        }

        private static string BuscarNodoConMinimaDistancia(Dictionary<string, double> distancias,
            HashSet<string> visitados)
        {
            var distanciaMinima = double.PositiveInfinity;
            var nodoDistanciaMinima = "";

            // Busco el nodo con minima distancia que todavia no haya visitado
            foreach (var distancia in distancias)
            {
                if (!visitados.Contains(distancia.Key) && distancia.Value <= distanciaMinima)
                {
                    distanciaMinima = distancia.Value;
                    nodoDistanciaMinima = distancia.Key;
                }
            }

            return nodoDistanciaMinima;
        }
    }
}