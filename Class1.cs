
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Program
    {
        public static List<Node> KahnAlgorithm(Graph graph)
        {
            var topSort = new List<Node>();
            var nodes = graph.Nodes.ToList();
            while (nodes.Count != 0)
            {
                var nodeToDelete = nodes
                    .Where(node => !node.IncidentEdges.Any(edge => edge.To == node))
                    .FirstOrDefault();

                if (nodeToDelete == null) return null;
                nodes.Remove(nodeToDelete);
                topSort.Add(nodeToDelete);
                foreach (var edge in nodeToDelete.IncidentEdges.ToList())
                    graph.Delete(edge);
            }
            return topSort;
        }
    }
}
