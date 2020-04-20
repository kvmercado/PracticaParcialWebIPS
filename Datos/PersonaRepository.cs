using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class PersonaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Persona> _personas = new List<Persona>();
        public PersonaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = @"Insert Into Persona (Identificacion,ValorHospitalizacion,Salario,ValorCopago) 
                                        values (@Identificacion,@ValorHospitalizacion,@Salario,@ValorCopago)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@ValorHospitalizacion", persona.ValorHospitalizacion);
                command.Parameters.AddWithValue("@Salario", persona.Salario);
                command.Parameters.AddWithValue("@ValorCopago", persona.ValorCopago);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Persona> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }

        private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.ValorHospitalizacion = (decimal)dataReader["ValorHospitalizacion"];
            persona.Salario = (decimal)dataReader["Salario"];
            persona.ValorCopago = (decimal)dataReader["ValorCopago"];
            
            return persona;
        }
    }
}