using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Train.Entities;
using Train.Services;

namespace Train.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private FileServices fileServics = new FileServices();
        private string _resultInfo = "";
        public string ResultInfo { get => _resultInfo; set { SetField(ref _resultInfo, value); } }

        private bool _costOrTime = false;
        public bool CostOrTime { get => _costOrTime; set { SetField(ref _costOrTime, value); } }

        private string _vertexStart = "";
        public string VertexStart { get => _vertexStart; set { SetField(ref _vertexStart, value); } }
        private string _vertexEnd = "";
        public string VertexEnd { get => _vertexEnd; set { SetField(ref _vertexEnd, value); } }

        private ObservableCollection<string> _vertex = new ObservableCollection<string>();
        public ObservableCollection<string> Vertex { get => _vertex; set { SetField(ref _vertex, value); } }

        private ObservableCollection<TrainPath> trainPath = new ObservableCollection<TrainPath>();
        public ObservableCollection<TrainPath> TrainsPath { get => trainPath; set { SetField(ref trainPath, value); } }

        public MainWindowViewModel()
        {
            LoadData();
        }   

        public async Task LoadData()
        {
            await foreach (var number in fileServics.ReadFile())
            {
                TrainsPath.Add(number);
            }

            (TrainsPath.AsParallel().Select(x => x.ArrivalStation).Distinct())
                .Union(TrainsPath.AsParallel().Select(x => x.DepartureStation).Distinct())
                .ToList()
                .ForEach(x => Vertex.Add(x));
        }

        public ICommand Search => new RelayCommand(() =>
        {
            if(VertexStart == "" || VertexEnd == "")
            {
                MessageBox.Show("Выберите пункт отправления и пункт прибытия!");
            } else if(VertexStart.Equals(VertexEnd))
            {
                MessageBox.Show("Выберите разные пынкты!");
            } else {
                ResultInfo = $"Начальная станция: {VertexStart}\n";
                var grService = new GraphService(Vertex, TrainsPath, CostOrTime);
                var result = grService.GetWay(VertexStart, VertexEnd);

                for (int i = 0; i < result.Train.Count; i++)
                {
                    var nextStation = i + 1;
                    ResultInfo += $"Номер поезда: {result.Train[i]} \n\tСтанция отправления: {result.Path[i]} --> Станция прибытия: {result.Path[nextStation]}\n";
                }

                ResultInfo += $"Конечная станция: {VertexEnd}";
            }
        });
    }
}
