using Microsoft.EntityFrameworkCore;
using SensorYapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorYapi.Services
{
    public class SensorClasterService : ISensorClasterService
    {
        private readonly SensorContext _Context;

        public SensorClasterService(SensorContext sensorContext)
        {
            this._Context = sensorContext;
        }


        public async Task<Sensor> CreateSensor(Sensor r)
        {
            _Context.Sensors.Add(r);
            await _Context.SaveChangesAsync();
            return r;
            //throw new NotImplementedException();
        }

        public async Task <bool> DeleteSensor(int id)
        {
            var r = await _Context.Sensors.FindAsync(id);
            if (r == null) return false;

            _Context.Sensors.Remove(r);
            await _Context.SaveChangesAsync();

            return true;
            //throw new NotImplementedException();
        }

        public async Task <List<Sensor>> GetAll()
        {
            return await _Context.Sensors.ToListAsync();
        }

        public async Task<Sensor> GetSensorById(int id)
        {
            return await _Context.Sensors.FindAsync(id);
        }

        public async Task <List<Sensor>> GetSensorsWhere(Expression<Func<Sensor, bool>> predicate)
        {
            return await _Context.Sensors.Where(predicate).ToListAsync();
        }

        public async Task< bool> UpdateSensor(int id, Sensor r)
        {
            if (id != r.Id)
                throw new ArgumentException();
            _Context.Entry(r).State = EntityState.Modified;

            var n = await _Context.SaveChangesAsync();
            return n == 1;

            //throw new NotImplementedException();
        }
    }
}
