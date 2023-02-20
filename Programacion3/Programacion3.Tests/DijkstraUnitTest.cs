using Programacion3.Algoritmos;
using Programacion3.Algoritmos.Utils;
using QuikGraph;
using Xunit;

namespace Programacion3.Tests
{
    public class DijkstraUnitTest
    {
        [Fact]
        public void Dijkstra_1()
        {
            var grafo = new UndirectedGraph<string, WeightedEdge<string>>();

            grafo.AddVertexRange(new[] { "Start", "A", "B", "Finish" });

            grafo.AddEdgeRange(new[]
            {
                new WeightedEdge<string>("Start", "A", 6),
                new WeightedEdge<string>("Start", "B", 2),
                new WeightedEdge<string>("A", "Finish", 1),
                new WeightedEdge<string>("B", "Finish", 5),
                new WeightedEdge<string>("B", "A", 3),
            });

            var distancias = AlgoritmosUtils.Dijkstra(grafo, "Start");

            Assert.Equal(4, distancias.Count);

            Assert.Equal(0, distancias["Start"]);
            Assert.Equal(5, distancias["A"]);
            Assert.Equal(2, distancias["B"]);
            Assert.Equal(6, distancias["Finish"]);
        }

        [Fact]
        public void Dijkstra_2()
        {
            var grafo = new UndirectedGraph<string, WeightedEdge<string>>();

            grafo.AddVertexRange(new[] { "A", "B", "C", "D", "E", "F", "G", "H" });

            grafo.AddEdgeRange(new[]
            {
                new WeightedEdge<string>("A", "C", 1),
                new WeightedEdge<string>("A", "B", 3),
                new WeightedEdge<string>("C", "F", 5),
                new WeightedEdge<string>("C", "D", 2),
                new WeightedEdge<string>("B", "D", 1),
                new WeightedEdge<string>("B", "G", 5),
                new WeightedEdge<string>("F", "H", 3),
                new WeightedEdge<string>("F", "D", 2),
                new WeightedEdge<string>("D", "E", 4),
                new WeightedEdge<string>("E", "H", 1),
                new WeightedEdge<string>("G", "E", 2),
            });

            var distancias = AlgoritmosUtils.Dijkstra(grafo, "A");

            Assert.Equal(8, distancias.Count);

            Assert.Equal(0, distancias["A"]);
            Assert.Equal(3, distancias["B"]);
            Assert.Equal(1, distancias["C"]);
            Assert.Equal(3, distancias["D"]);
            Assert.Equal(7, distancias["E"]);
            Assert.Equal(5, distancias["F"]);
            Assert.Equal(8, distancias["G"]);
            Assert.Equal(8, distancias["H"]);
        }
    }
}