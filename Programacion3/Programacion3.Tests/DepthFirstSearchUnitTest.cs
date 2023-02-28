using Programacion3.Algoritmos;
using QuikGraph;
using Xunit;

namespace Programacion3.Tests
{
    public class DepthFirstSearchUnitTest
    {
        [Fact]
        public void DepthFirstSearch()
        {
            var grafo = new UndirectedGraph<string, Edge<string>>();

            grafo.AddVertexRange(new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" });

            grafo.AddEdgeRange(new[]
            {
                new TaggedEdge<string, string>("A", "B", "A-B"),
                new TaggedEdge<string, string>("B", "C", "B-C"),
                new TaggedEdge<string, string>("C", "D", "C-D"),
                new TaggedEdge<string, string>("A", "E", "A-E"),
                new TaggedEdge<string, string>("A", "E", "A-E"),
                new TaggedEdge<string, string>("E", "F", "E-F"),
                new TaggedEdge<string, string>("F", "G", "F-G"),
                new TaggedEdge<string, string>("E", "H", "E-H"),
                new TaggedEdge<string, string>("A", "I", "A-I"),
                new TaggedEdge<string, string>("I", "J", "I-J"),
                new TaggedEdge<string, string>("K", "L", "K-L"),
            });
            
            var nodosVisitados = AlgoritmosUtils.DepthFirstSearch(grafo, "A");
            
            Assert.Equal(10, nodosVisitados.Length);

            Assert.Equal("A", nodosVisitados[0]);
            Assert.Equal("B", nodosVisitados[1]);
            Assert.Equal("C", nodosVisitados[2]);
            Assert.Equal("D", nodosVisitados[3]);
            Assert.Equal("E", nodosVisitados[4]);
            Assert.Equal("F", nodosVisitados[5]);
            Assert.Equal("G", nodosVisitados[6]);
            Assert.Equal("H", nodosVisitados[7]);
            Assert.Equal("I", nodosVisitados[8]);
            Assert.Equal("J", nodosVisitados[9]);

            Assert.DoesNotContain("K", nodosVisitados);
            Assert.DoesNotContain("L", nodosVisitados);
        }
    }
}