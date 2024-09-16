using CorrectionExoIOT.DAL.Entities;
using CorrectionExoIOT.DAL.Enums;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionExoIOT.DAL.Repositories
{
    public class InfoMaisonRepository
    {
        private readonly SqlConnection _connection;

        public InfoMaisonRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<InfoMaison> GetInfo(InfoType type, DateTime start, DateTime? end = null)
        {
            string query = @"
                SELECT * FROM InfoMaison 
                WHERE 
                    Type = @Type 
                    AND Date >= @Start 
                    AND (@End IS NULL OR Date <= @End)
                ";
            return _connection.Query<InfoMaison>(query, new
            {
                Type = type,
                Start = start,
                End = end
            }).ToList();
        }

        public void Insert(InfoMaison info)
        {
            string query = "INSERT INTO InfoMaison VALUES (@Value, @Date, @Type)";
            _connection.Execute(query, info);
        }
    }
}
