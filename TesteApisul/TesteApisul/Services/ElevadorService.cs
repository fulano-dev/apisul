using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TesteApisul.Interfaces;
using TesteApisul.Models;

namespace TesteApisul.Classes
{
    public class ElevadorService : IElevadorService
    {
        private List<ElevadorModel> _data;

        public ElevadorService(string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            _data = JsonSerializer.Deserialize<List<ElevadorModel>>(json);
        }

        public List<int> andarMenosUtilizado()
        {
            Dictionary<int, int> contadorAndares = new Dictionary<int, int>();
            foreach (var item in _data)
            {
                if (contadorAndares.ContainsKey(item.andar))
                {
                    contadorAndares[item.andar]++;
                }
                else
                {
                    contadorAndares[item.andar] = 1;
                }
            }
            int menorContagem = contadorAndares.Values.Min();
            List<int> menosUtilizados = contadorAndares.Where(pair => pair.Value == menorContagem)
                                               .Select(pair => pair.Key)
                                               .ToList();

            return menosUtilizados;
        }

        public List<char> elevadorMaisFrequentado()
        {
            var contadorElevador = new Dictionary<char, int>();

            foreach (var item in _data)
            {
                if (!contadorElevador.ContainsKey(item.elevador))
                {
                    contadorElevador[item.elevador] = 0;
                }

                contadorElevador[item.elevador]++;
            }

            var maiorContagem = contadorElevador.Max(x => x.Value);

            var elevadoresMaisFrequentados = contadorElevador.Where(x => x.Value == maiorContagem)
                                                              .Select(x => x.Key)
                                                              .ToList();

            return elevadoresMaisFrequentados;
        }

        public List<char> elevadorMenosFrequentado()
        {
            var contadorElevador = new Dictionary<char, int>();

            foreach (var item in _data)
            {
                if (!contadorElevador.ContainsKey(item.elevador))
                {
                    contadorElevador[item.elevador] = 0;
                }

                contadorElevador[item.elevador]++;
            }

            var menorContagem = contadorElevador.Min(x => x.Value);

            var elevadoresMenosFrequentados = contadorElevador.Where(x => x.Value == menorContagem)
                                                              .Select(x => x.Key)
                                                              .ToList();

            return elevadoresMenosFrequentados;
        }

        public float percentualDeUsoElevadorA()
        {
            int totalServicos = _data.Count;

            int totalUsosElevadorA = _data.Count(item => item.elevador == 'A');

            float percentual = ((float)totalUsosElevadorA / totalServicos) * 100;

            return percentual = (float)Math.Round(percentual, 2); ;
        }

        public float percentualDeUsoElevadorB()
        {
            int totalServicos = _data.Count;

            int totalUsosElevadorA = _data.Count(item => item.elevador == 'B');

            float percentual = ((float)totalUsosElevadorA / totalServicos) * 100;

            return percentual = (float)Math.Round(percentual, 2); ;
        }

        public float percentualDeUsoElevadorC()
        {
            int totalServicos = _data.Count;

            int totalUsosElevadorA = _data.Count(item => item.elevador == 'C');

            float percentual = ((float)totalUsosElevadorA / totalServicos) * 100;

            return percentual = (float)Math.Round(percentual, 2); ;
        }

        public float percentualDeUsoElevadorD()
        {
            int totalServicos = _data.Count;

            int totalUsosElevadorA = _data.Count(item => item.elevador == 'D');

            float percentual = ((float)totalUsosElevadorA / totalServicos) * 100;

            return percentual = (float)Math.Round(percentual, 2); ;
        }

        public float percentualDeUsoElevadorE()
        {
            int totalServicos = _data.Count;

            int totalUsosElevadorA = _data.Count(item => item.elevador == 'E');

            float percentual = ((float)totalUsosElevadorA / totalServicos) * 100;

            return percentual = (float)Math.Round(percentual, 2); ;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var elevadoresMaisFrequentados = elevadorMaisFrequentado();

            var contadorPeriodos = _data
                .Where(item => elevadoresMaisFrequentados.Contains(item.elevador))
                .GroupBy(item => item.turno)
                .Select(g => new { Turno = g.Key, Total = g.Count() })
                .OrderByDescending(x => x.Total)
                .ToList();

            var maiorTotal = contadorPeriodos.First().Total;

            var periodos = contadorPeriodos
                .Where(x => x.Total == maiorTotal)
                .Select(x => x.Turno)
                .ToList();

            return periodos;

        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var contadorPeriodos = _data
            .GroupBy(item => item.turno)
            .Select(g => new { Turno = g.Key, Total = g.Count() })
            .OrderByDescending(x => x.Total)
            .ToList();

            var maiorTotal = contadorPeriodos.First().Total;

            var periodos = contadorPeriodos
                .Where(x => x.Total == maiorTotal)
                .Select(x => x.Turno)
                .ToList();

            return periodos;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var elevadoresMenosFrequentados = elevadorMenosFrequentado();

            var contadorPeriodos = _data
                .Where(item => elevadoresMenosFrequentados.Contains(item.elevador))
                .GroupBy(item => item.turno)
                .Select(g => new { Turno = g.Key, Total = g.Count() })
                .OrderBy(x => x.Total)
                .ToList();

            var menorTotal = contadorPeriodos.First().Total;

            var periodos = contadorPeriodos
                .Where(x => x.Total == menorTotal)
                .Select(x => x.Turno)
                .ToList();

            return periodos;
        }
    }
}
