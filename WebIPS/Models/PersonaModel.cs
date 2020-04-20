using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIPS.Models
{
        public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public decimal ValorHospitalizacion { get; set; }
        public decimal Salario { get; set; }
        
    }
    
    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            ValorHospitalizacion = persona.ValorHospitalizacion;
            Salario = persona.Salario;
            ValorCopago = persona.ValorCopago;
            
        }
        public decimal ValorCopago { get; set; }
    }
}