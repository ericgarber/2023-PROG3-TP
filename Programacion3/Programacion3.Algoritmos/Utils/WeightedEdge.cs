using QuikGraph;

namespace Programacion3.Algoritmos.Utils
{
    public class WeightedEdge<TVertex> : Edge<TVertex>
    {
        public double Weight { get; set; }

        public WeightedEdge(TVertex source, TVertex target, double weight)
            : base(source, target)
        {
            Weight = weight;
        }
    }
}