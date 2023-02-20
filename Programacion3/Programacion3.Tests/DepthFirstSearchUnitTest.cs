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

            grafo.AddVertexRange(new[] { "A", "B", "C", "D", "E", "F", "G", "H" });

            grafo.AddEdgeRange(new[]
            {
                new TaggedEdge<string, string>("A", "B", "A-B"),
                new TaggedEdge<string, string>("A", "C", "A-C"),
                new TaggedEdge<string, string>("B", "D", "B-D"),
                new TaggedEdge<string, string>("B", "E", "B-E"),
                new TaggedEdge<string, string>("C", "E", "C-E"),
                new TaggedEdge<string, string>("E", "F", "E-F"),
                new TaggedEdge<string, string>("G", "H", "G-H"),
            });
            
            var nodosVisitados = AlgoritmosUtils.DepthFirstSearch(grafo, "A");
            
            Assert.Equal(6, nodosVisitados.Length);

            Assert.Equal("A", nodosVisitados[0]);
            Assert.Equal("B", nodosVisitados[1]);
            Assert.Equal("C", nodosVisitados[2]);
            Assert.Equal("E", nodosVisitados[3]);
            Assert.Equal("F", nodosVisitados[4]);
            Assert.Equal("D", nodosVisitados[5]);

            Assert.DoesNotContain("G", nodosVisitados);
            Assert.DoesNotContain("H", nodosVisitados);
        }
    }
}