using CalculadoraEstatisca.Arguments.Class;
using CalculadoraEstatisca.Arguments.Class.Base;

namespace CalculadoraEstatisca.Domain.Interface;

public interface IStatisticalCalculatorService
{
    OutputNotContinuous CalculateNotGrouped(InputNotGroupedValue listNumber);
    OutputNotContinuous CalculateGrouped(InputGroupedValue inputGroupedValue);
    OutputContinuous CalculeteContinuousData(InputValueContinuous inputValueContinuous);
}