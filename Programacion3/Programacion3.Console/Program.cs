using System;
using Microsoft.VisualStudio.GraphModel;
using Programacion3.Algoritmos;

namespace Programacion3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            var nodeA = graph.Nodes.GetOrCreate("A");
            var nodeB = graph.Nodes.GetOrCreate("B");
            var nodeC = graph.Nodes.GetOrCreate("C");
            var nodeD = graph.Nodes.GetOrCreate("D");
            var nodeE = graph.Nodes.GetOrCreate("E");
            var nodeF = graph.Nodes.GetOrCreate("F");
            var nodeG = graph.Nodes.GetOrCreate("G");
            var nodeH = graph.Nodes.GetOrCreate("H");

            graph.Links.GetOrCreate(nodeA, nodeB); // A -> B
            graph.Links.GetOrCreate(nodeA, nodeC); // A -> C
            graph.Links.GetOrCreate(nodeB, nodeD); // B -> D
            graph.Links.GetOrCreate(nodeB, nodeE); // B -> E
            graph.Links.GetOrCreate(nodeC, nodeE); // C -> E
            graph.Links.GetOrCreate(nodeE, nodeF); // E -> F
            graph.Links.GetOrCreate(nodeG, nodeH); // G -> H

            var result = AlgoritmosBusqueda.BreadthFirstSearch(nodeA);
        }
    }
}