namespace Train.Entities
{
    /// <summary>
    /// Информация о вершине
    /// </summary>
    public class GraphVertexInfo
    {
        /// <summary>
        /// Вершина
        /// </summary>
        public GraphVertex Vertex { get; set; }

        /// <summary>
        /// Не посещенная вершина
        /// </summary>
        public bool IsUnvisited { get; set; }

        /// <summary>
        /// Сумма весов ребер
        /// </summary>
        public double EdgesWeightSum { get; set; }
        
        public double weight { get; set; }
        public string train { get; set; }
        
        /// <summary>
        /// Предыдущая вершина
        /// </summary>
        public GraphVertex PreviousVertex { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="vertex">Вершина</param>
        public GraphVertexInfo(GraphVertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            EdgesWeightSum = int.MaxValue;
            PreviousVertex = null;
            weight = 0;
            train = "";
        }
    }
}
