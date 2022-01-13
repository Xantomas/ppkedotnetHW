using Microsoft.AspNetCore.Mvc;
using SensorYapi.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorYapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly SensorClasterService _sensorClasterService;
        private readonly ILogger<SensorsController> _logger;

        public SensorsController(SensorClasterService sensorClasterService, ILogger<SensorsController> logger)
        {
            _sensorClasterService = sensorClasterService;
            this._logger = logger;
        }

        // GET: api/<SensorsController>
        [HttpGet]
        public IEnumerable<Sensor> GetAll()
        {
            _logger.LogInformation("GelAll called.");
            return _sensorClasterService.GetAll();
        }

        // GET api/<SensorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var r= _sensorClasterService.GetSensorById(id);
            if (r == null)
            { return NotFound(); }
            return Ok(r);
        }

        // POST api/<SensorsController>
        [HttpPost]
        public IActionResult Post([FromBody] Sensor r)
        {
            var createdSensor = _sensorClasterService.CreateSensor(r);

            return CreatedAtAction( nameof(Get), new { id = createdSensor.Id}, createdSensor);
        }

        // PUT api/<SensorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Sensor r)
        {
            return _sensorClasterService.UpdateSensor(id, r)
                ? NoContent()
                : NotFound();
        }

        // DELETE api/<SensorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _sensorClasterService.DeleteSensor(id)
                ? NoContent()
                : NotFound();
        }
    }
}
