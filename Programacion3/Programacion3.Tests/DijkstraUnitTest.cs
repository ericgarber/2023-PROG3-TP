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
            var grafo = new BidirectionalGraph<string, TaggedEdge<string, double>>();

            grafo.AddVertexRange(new[] { "Start", "A", "B", "Finish" });

            grafo.AddEdgeRange(new[]
            {
                new TaggedEdge<string, double>("Start", "A", 6),
                new TaggedEdge<string, double>("Start", "B", 2),
                new TaggedEdge<string, double>("A", "Finish", 1),
                new TaggedEdge<string, double>("B", "Finish", 5),
                new TaggedEdge<string, double>("B", "A", 3),
            });

            var (distancias, padres) = AlgoritmosUtils.Dijkstra(grafo, "Start");

            Assert.Equal(4, distancias.Count);

            Assert.Equal(0, distancias["Start"]);
            Assert.Equal(5, distancias["A"]);
            Assert.Equal(2, distancias["B"]);
            Assert.Equal(6, distancias["Finish"]);
            
            Assert.Equal(3, padres.Count);

            Assert.Equal("B", padres["A"]);
            Assert.Equal("Start", padres["B"]);
            Assert.Equal("A", padres["Finish"]);
        }

        [Fact]
        public void Dijkstra_2()
        {
            var grafo = new BidirectionalGraph<string, TaggedEdge<string, double>>();

            grafo.AddVertexRange(new[] { "A", "B", "C", "D", "E", "F" });

            grafo.AddEdgeRange(new[]
            {
                new TaggedEdge<string, double>("A", "C", 40),
                new TaggedEdge<string, double>("A", "E", 10),
                new TaggedEdge<string, double>("A", "F", 5),
                new TaggedEdge<string, double>("B", "D", 5),
                new TaggedEdge<string, double>("C", "B", 10),
                new TaggedEdge<string, double>("C", "E", 5),
                new TaggedEdge<string, double>("D", "C", 5),
                new TaggedEdge<string, double>("E", "D", 20),
                new TaggedEdge<string, double>("F", "E", 10),
                new TaggedEdge<string, double>("F", "B", 20),
            });

            var (distancias, padres) = AlgoritmosUtils.Dijkstra(grafo, "A");

            Assert.Equal(6, distancias.Count);

            Assert.Equal(0, distancias["A"]);
            Assert.Equal(25, distancias["B"]);
            Assert.Equal(35, distancias["C"]);
            Assert.Equal(30, distancias["D"]);
            Assert.Equal(10, distancias["E"]);
            Assert.Equal(5, distancias["F"]);
            
            Assert.Equal(5, padres.Count);

            Assert.Equal("D", padres["C"]);
            Assert.Equal("A", padres["E"]);
            Assert.Equal("A", padres["F"]);
            Assert.Equal("F", padres["B"]);
            Assert.Equal("E", padres["D"]);
        }
    }
}