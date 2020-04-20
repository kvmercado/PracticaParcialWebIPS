namespace Entity
{
    public class Persona
    {
        
        public string Identificacion { get; set; }
        public decimal ValorHospitalizacion { get; set; }
        public decimal Salario { get; set; }
        public decimal ValorCopago { get; set; }

        public void CalcularCopago()
        {
            if (Salario>2500000)
            {
                ValorCopago=(ValorHospitalizacion*20/100);
            }else{
                ValorCopago=(ValorHospitalizacion*10/100);
            }
        }
    }
}