using CorrectionExoIOT.DAL.Entities;
using CorrectionExoIOT.DAL.Enums;
using CorrectionExoIOT.DAL.Repositories;
using CorrectionExoIOT.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorrectionExoIOT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController(
        InfoMaisonRepository infoMaisonRepository
    ) : ControllerBase
    {

        [HttpGet]
        public IActionResult Get([FromQuery] DateTime start)
        {
            List<InfoMaison> data = infoMaisonRepository.GetInfo(InfoType.Temperature, start);

            List<TemperatureDTO> dto = data.Select(e => new TemperatureDTO
            {
                Date = e.Date,
                Value = e.Value,
            }).ToList();

            return Ok(dto);
        }

    }
}
