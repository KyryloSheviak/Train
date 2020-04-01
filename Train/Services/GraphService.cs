using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Train.Entities;

namespace Train.Services
{
    public class GraphService
    {
        public Graph graph = new Graph();

        public GraphService(ObservableCollection<string> vertex, ObservableCollection<TrainPath> edges, bool flag)
        {
            foreach (var item in vertex)
                graph.AddVertex(item);

            //добавление ребер
            if (flag)
            {
                foreach (var item in edges)
                    graph.AddEdge(item.DepartureStation, item.ArrivalStation, item.DateDiff, item.TrainNumber);
            }
            else
            {
                foreach (var item in edges)
                    graph.AddEdge(item.DepartureStation, item.ArrivalStation, item.Cost, item.TrainNumber);
            }
        }

        public ResultPath GetWay(string vertexStart, string VertexEnd)
        {
            var dijkstra = new Dijkstra(graph);
            var result = dijkstra.FindShortestPath(vertexStart, VertexEnd);
            return result;
        }
    }
}
