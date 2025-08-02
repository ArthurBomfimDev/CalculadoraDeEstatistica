using CalculadoraEstatisca.Arguments.Class;
using CalculadoraEstatisca.Arguments.Class.Base;
using CalculadoraEstatisca.Domain.Interface;

namespace CalculadoraEstatisca.Domain.Service.General;

public class StatisticalCalculatorService : IStatisticalCalculatorService
{
    private readonly ITableService _tableService;
    private readonly IAverageService _averageService;
    private readonly IMedianService _medianService;
    private readonly IModeService _modeService;
    private readonly IStandardDeviationService _standardDeviationService;

    public StatisticalCalculatorService(ITableService tableService, IAverageService averageService, IMedianService medianService, IModeService modeService, IStandardDeviationService standardDeviationService)
    {
        _tableService = tableService;
        _averageService = averageService;
        _medianService = medianService;
        _modeService = modeService;
        _standardDeviationService = standardDeviationService;
    }


    public OutputNotContinuous CalculateNotGrouped(InputNotGroupedValue inputValue)
    {
        OutputNotContinuous returnNotGrouped = new();
        var listNumber = inputValue.ListNumber.OrderBy(i => i).ToList();

        if (inputValue.Average)
            returnNotGrouped.Average = _averageService.CalculateNotGrouped(listNumber);

        if (inputValue.Median)
            returnNotGrouped.Median = _medianService.CalculateNotGrouped(listNumber);

        if (inputValue.Mode)
            returnNotGrouped.Mode = _modeService.CalculateNotGrouped(listNumber);

        if (inputValue.StandardDeviation)
            returnNotGrouped.StandardDeviation = _standardDeviationService.CalculateNotGrouped(listNumber);

        return returnNotGrouped;
    }

    public OutputNotContinuous CalculateGrouped(InputGroupedValue inputGroupedValue)
    {
        var listNumber = _tableService.GetListNumber(inputGroupedValue.InputGroupedTable);

        return CalculateNotGrouped(new InputNotGroupedValue(listNumber, inputGroupedValue.Average, inputGroupedValue.Median, inputGroupedValue.Mode, inputGroupedValue.StandardDeviation));
        //returnAgrouped.Table = table;

        //if (table == default)
        //    throw new ArgumentException("Erro - A tabela está vazia, verifique os dados");

        //if (inputValue.Average)
        //    returnAgrouped.Average = _averageService.CalculateGrouped(table);

        //if (inputValue.Median)
        //    returnAgrouped.Median = _medianService.CalculateGrouped(table);

        //if (inputValue.Mode)
        //    returnAgrouped.Mode = _modeService.CalculateGrouped(table);

        //if (inputValue.StandardDeviation)
        //    returnAgrouped.StandardDeviation = _standardDeviationService.CalculateGrouped(table);

        //return returnAgrouped;
    }

    public OutputContinuous CalculeteContinuousData(InputValueContinuous inputValueContinuous)
    {
        OutputContinuous returnAgrouped = new();

        var table = _tableService.GetContinuosTable(inputValueContinuous.inputTable);
        returnAgrouped.Table = table;

        if (table == default)
            throw new ArgumentException("Erro - A tabela está vazia, verifique os dados");

        if (inputValueContinuous.Average)
            returnAgrouped.Average = _averageService.CalculateContinuous(table);

        if (inputValueContinuous.Median)
            returnAgrouped.Median = _medianService.CalculateContinuos(table);

        if (inputValueContinuous.Mode)
            returnAgrouped.Mode = _modeService.CalculateContinuous(table);

        if (inputValueContinuous.StandardDeviation)
            returnAgrouped.StandardDeviation = _standardDeviationService.CalculateContinuos(table);

        return returnAgrouped;
    }
}