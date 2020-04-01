namespace Train.Entities
{
    /// <summary>
    /// Ребро графа
    /// </summary>
    public class GraphEdge
    {
        /// <summary>
        /// Связанная вершина
        /// </summary>
        public GraphVertex ConnectedVertex { get; }

        /// <summary>
        /// Вес ребра
        /// </summary>
        public double EdgeWeight { get; }

        public string Train { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectedVertex">Связанная вершина</param>
        /// <param name="weight">Вес ребра</param>
        public GraphEdge(GraphVertex connectedVertex, double weight, string train)
        {
            ConnectedVertex = connectedVertex;
            EdgeWeight = weight;
            Train = train;
        }
    }
}
