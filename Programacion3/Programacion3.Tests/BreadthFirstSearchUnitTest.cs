using Programacion3.Algoritmos;
using QuikGraph;
using Xunit;

namespace Programacion3.Tests
{
    public class BreadthFirstSearchUnitTest
    {
        [Fact]
        public void BreadthFirstSearch()
        {
            var graph = new UndirectedGraph<string, Edge<string>>();

            graph.AddVertexRange(new[] { "A", "B", "C", "D", "E", "F", "G", "H" });
            
            graph.AddEdgeRange(new[]
            {
                new TaggedEdge<string, string>("A", "B", "A-B"),
                new TaggedEdge<string, string>("A", "C", "A-C"),
                new TaggedEdge<string, string>("B", "D", "B-D"),
                new TaggedEdge<string, string>("B", "E", "B-E"),
                new TaggedEdge<string, string>("C", "E", "C-E"),
                new TaggedEdge<string, string>("E", "F", "E-F"),
                new TaggedEdge<string, string>("G", "H", "G-H"),
            });
            
            var nodosVisitados = AlgoritmosBusqueda.BreadthFirstSearch(graph, "A");
            
            Assert.Equal(6, nodosVisitados.Count);

            Assert.Contains("A", nodosVisitados);
            Assert.Contains("B", nodosVisitados);
            Assert.Contains("C", nodosVisitados);
            Assert.Contains("D", nodosVisitados);
            Assert.Contains("E", nodosVisitados);
            Assert.Contains("F", nodosVisitados);

            Assert.DoesNotContain("G", nodosVisitados);
            Assert.DoesNotContain("H", nodosVisitados);
        }
    }
}