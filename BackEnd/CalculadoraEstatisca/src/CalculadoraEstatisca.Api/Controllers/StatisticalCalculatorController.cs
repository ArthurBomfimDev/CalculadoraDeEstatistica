using CalculadoraEstatisca.Arguments.Class;
using CalculadoraEstatisca.Arguments.Class.Base;
using CalculadoraEstatisca.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraEstatisca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticalCalculatorController : ControllerBase
{
    private readonly IStatisticalCalculatorService _statisticalCalculatorService;

    public StatisticalCalculatorController(IStatisticalCalculatorService statisticalCalculatorService)
    {
        _statisticalCalculatorService = statisticalCalculatorService;
    }

    [HttpPost("NotGrouped")]
    public ActionResult<OutputNotContinuous> CalculeteNotGrouped(InputNotGroupedValue inputNotGroupedValue)
    {
        OutputNotContinuous calculete = _statisticalCalculatorService.CalculateNotGrouped(inputNotGroupedValue);
        return calculete;
    }

    [HttpPost("Grouped")]
    public ActionResult<OutputNotContinuous> CalculeteGrouped(InputGroupedValue inputGroupedValue)
    {
        OutputNotContinuous calculete = _statisticalCalculatorService.CalculateGrouped(inputGroupedValue);
        return calculete;
    }

    [HttpPost("ContinuousData")]
    public ActionResult<OutputContinuous> CalculeteContinuousData(InputValueContinuous inputValueContinuos)
    {
        OutputContinuous calculete = _statisticalCalculatorService.CalculeteContinuousData(inputValueContinuos);
        return calculete;
    }
}
