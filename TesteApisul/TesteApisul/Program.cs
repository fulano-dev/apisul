using TesteApisul.Classes;

var service = new ElevadorService(@"C:\apisul\input.json");

var andarMenosUtilizado = service.andarMenosUtilizado();
Console.WriteLine("Andar(es) menos utilizado(s): " + string.Join(", ", andarMenosUtilizado));

var elevadorMaisFrequentado = service.elevadorMaisFrequentado();
Console.WriteLine("Eevadores(es) mais utilizado(s): " + string.Join(", ", elevadorMaisFrequentado));

var elevadorMenosFrequentado = service.elevadorMenosFrequentado();
Console.WriteLine("Eevadores(es) menos utilizado(s): " + string.Join(", ", elevadorMenosFrequentado));

var percentualUsoA = service.percentualDeUsoElevadorA();
Console.WriteLine("O percetual de uso do elevador A é " + percentualUsoA+"%");

var percentualUsoB = service.percentualDeUsoElevadorB();
Console.WriteLine("O percetual de uso do elevador B é " + percentualUsoB + "%");

var percentualUsoC = service.percentualDeUsoElevadorC();
Console.WriteLine("O percetual de uso do elevador C é " + percentualUsoC + "%");

var percentualUsoD = service.percentualDeUsoElevadorD();
Console.WriteLine("O percetual de uso do elevador D é " + percentualUsoD + "%");

var percentualUsoE = service.percentualDeUsoElevadorE();
Console.WriteLine("O percetual de uso do elevador E é " + percentualUsoE + "%");

var periodosMaiorFluxo = service.periodoMaiorFluxoElevadorMaisFrequentado();
Console.WriteLine("Período(s) de maior fluxo dos elevadores mais frequentados: " + string.Join(", ", periodosMaiorFluxo));

var periodosMenorFluxoElevadorMenosFrequentado = service.periodoMenorFluxoElevadorMenosFrequentado();
Console.WriteLine("Período(s) de menor fluxo dos elevadores menos frequentados: " + string.Join(", ", periodosMenorFluxoElevadorMenosFrequentado));

var periodosMaiorUtilizacaoConjuntoElevadores = service.periodoMaiorUtilizacaoConjuntoElevadores();
Console.WriteLine("Período(s) de maior utilização em que todos os elevadores são mais utilizados: " + string.Join(", ", periodosMaiorUtilizacaoConjuntoElevadores));

Console.ReadLine();