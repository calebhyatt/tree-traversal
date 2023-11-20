using Caleb_Hyatt_Graph_Final;

// Setup
Graph graph = new();

graph.AddEdge(0, 1, 20);
graph.AddEdge(0, 2, 15);
graph.AddEdge(0, 5, 10);
graph.AddEdge(1, 2, 40);
graph.AddEdge(1, 5, 30);
graph.AddEdge(2, 3, 10);
graph.AddEdge(3, 4, 15);
graph.AddEdge(5, 6, 20);

Console.WriteLine("===== Scenario 1 =====\n");
graph.Traverse(0);

Console.WriteLine("\n===== Scenario 2 =====\n");
graph.Traverse(6);

Console.WriteLine("\n===== Scenario 3 =====\n");
Console.WriteLine($"Total Cost: {graph.TotalCost(0)}");

Console.WriteLine("\n===== Scenario 4 =====\n");
graph.GetNeighborsAndWeights(0);

Console.WriteLine("\n===== Scenario 5 =====\n");
// Is it okay to call it RemoveNode instead of Remove?
graph.RemoveNode(4);

Console.WriteLine("\n===== Scenario 6 =====\n");
Console.WriteLine($"Total Cost: {graph.TotalCost(3)}");

Console.WriteLine("\n===== Scenario 7 =====\n");
graph.GetNeighborsAndWeights(3);
