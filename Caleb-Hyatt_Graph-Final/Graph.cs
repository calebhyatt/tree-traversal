namespace Caleb_Hyatt_Graph_Final
{
    class Graph
    {
        // Props
        private Dictionary<int, Dictionary<int, int>> adjacencyList;

        // Constructors
        public Graph()
        {
            adjacencyList = new();
        }
        
        // Methods
        public Graph AddNode(int node)
        {
            adjacencyList.Add(node, new());

            return this;
        }

        public Graph RemoveNode(int node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                Console.WriteLine("Node not found in graph.");
                return this;
            }

            var neighbors = adjacencyList[node];
            foreach (var neighbor in neighbors)
            {
                adjacencyList[neighbor.Key].Remove(node);
            }

            adjacencyList.Remove(node);
            Console.WriteLine($"Node {node} successfully removed.");

            return this;
        }

        public Graph AddEdge(int node1, int node2, int weight)
        {
            if (!adjacencyList.ContainsKey(node1))
            {
                AddNode(node1);
            }
            if (!adjacencyList.ContainsKey(node2))
            {
                AddNode(node2);
            }

            adjacencyList[node1].Add(node2, weight);
            adjacencyList[node2].Add(node1, weight);

            return this;
        }

        public int Traverse(int startNode, bool getCost = false)
        {
            int totalCost = 0;
            if (!adjacencyList.ContainsKey(startNode))
            {
                Console.WriteLine("Node not found in graph.");
                return 0;
            }

            List<int> visited = new();
            Stack<int> upNext = new();

            upNext.Push(startNode);

            /**
             * Can we jump over nodes or do we have to back up?
             */
            while (visited.Count < adjacencyList.Count)
            {
                int node = upNext.Pop();

                if (!getCost)
                {
                    Console.WriteLine($"Visited node {node}");
                }

                if (!visited.Contains(node))
                {
                    visited.Add(node);
                }

                foreach (var neighbor in adjacencyList[node])
                {
                    if (getCost)
                    {
                        totalCost += neighbor.Value;
                    }
                    
                    if (!visited.Contains(neighbor.Key))
                    {
                        upNext.Push(neighbor.Key);
                    }
                }
            }

            return totalCost / 2;
        }

        public void GetNeighborsAndWeights(int node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                Console.WriteLine("Node not found in graph.");
                return;
            }

            var sortedNeighbors = adjacencyList[node].OrderByDescending(x => x.Value);

            foreach (var neighbor in sortedNeighbors)
            {
                Console.WriteLine($"node {neighbor.Key} - {neighbor.Value}");
            }
        }

        public int TotalCost(int startNode)
        {
            return Traverse(startNode, true);
        }
    }
}
