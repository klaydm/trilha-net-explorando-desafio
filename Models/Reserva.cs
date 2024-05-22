using System.Security.Cryptography.X509Certificates;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Feat: Adicionada verificação de capacidade na suíte

            bool capacidadeDaSuite = Suite.Capacidade >= hospedes.Count();

            if (capacidadeDaSuite)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Feat: Adicionada Exception para quando a capacidade for exercida
                throw new Exception("Quantidade de hóspedes é maior que a capacidade da suíte");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Feat: Adicionado retorno com a quantidade de hóspedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Feat: Calculando diária de acordo com a quantidade de dias reservados
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Feat: Adicionado cálculo de 10% para quando a quantidade de dias reservados for igual ou maior que 10 
            bool verificarDiasReservados = DiasReservados >= 10;

            if (verificarDiasReservados)
            {
                valor -= valor * 0.1M;
            }

            return valor;
        }
    }
}