using System.Collections.Generic;
using System.Data.SQLite;
using System;


namespace MetricsAgent.DAL
{
    public interface ICpuMetricRepository : IRepository<CpuMetric>
    {

    }




    public class CpuMetricRepository : ICpuMetricRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public void Create(CpuMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "INSERT INTO cpumetrics(value, time) VALUES (@value, @time);";
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void Delete(CpuMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "DELETE FROM cpumetrics WHERE id = @id;";
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<CpuMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "SELECT * FROM cpumetrics";

            var returnList = new List<CpuMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    CpuMetric item = new CpuMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(2))
                    };

                    returnList.Add(item);

                }
                return returnList;
            }
        }

        public CpuMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "SELECT * FROM cpumetrics WHERE id=@id";

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new CpuMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(2))
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public IList<CpuMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            int fromT = Convert.ToInt32(fromTime.TotalSeconds);
            int toT = Convert.ToInt32(toTime.TotalSeconds);

            cmd.CommandText = $"SELECT * FROM cpumetrics WHERE time >= {fromT} AND time <= {toT}";

            var returnList = new List<CpuMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    CpuMetric item = new CpuMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(2))
                    };

                    returnList.Add(item);

                }
                return returnList;
            }
        }

        public void Update(CpuMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "UPDATE cpumetrics SET value = @value, time = @time WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time.TotalSeconds);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
