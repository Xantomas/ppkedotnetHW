using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorYapi.Models
{
    public class SensorClasterService
    {
        private List<Sensor> sensors = new List<Sensor>
        {
                new Sensor
                {
                    Id = 1,
                    Name = "Room1_thermal",
                    Type=  "Thermal",
                    Version = "v1.0",
                    LastValue= 100
                }
        };
        public Sensor CreateSensor(Sensor r)
        {
            r.Id = sensors.Max(x => x.Id) + 1;
            sensors.Add(r);
            return r;
        }

        public List<Sensor> GetAll()
        {
            return sensors.ToList();
        }

        public List<Sensor> GetSensorsWhere(Func<Sensor, bool> predicate)
        {
            return sensors.Where(predicate).ToList();
        }

        public Sensor GetSensorById( int id)
        {
            return sensors.SingleOrDefault(x => x.Id == id);
        }

        public bool UpdateSensor(int id, Sensor r)
        {
            var sensorToUpdate = sensors.SingleOrDefault(x => x.Id == id);

            if (sensorToUpdate == null)
                return false;

            sensorToUpdate.Name = r.Name;
            sensorToUpdate.LastValue = r.LastValue;
            sensorToUpdate.Version = r.Version;
            sensorToUpdate.Type=    r.Type;

            return true;
        }

        public bool DeleteSensor(int id)
        {
            var n= sensors.RemoveAll(x => x.Id == id);
            return n == 1;
        }
    }
}
