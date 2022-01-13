using SensorYapi.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorYapi.Services
{
    public interface ISensorClasterService
    {
        Task <Sensor> CreateSensor(Sensor r);
        Task <bool> DeleteSensor(int id);
        Task <List<Sensor>> GetAll();
        Task <Sensor> GetSensorById(int id);
        Task <List<Sensor>> GetSensorsWhere(Expression <Func<Sensor, bool>> predicate);
        Task <bool> UpdateSensor(int id, Sensor r);
    }
}
