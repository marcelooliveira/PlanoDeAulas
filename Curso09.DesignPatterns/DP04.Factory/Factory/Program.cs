using System;

namespace Factory
{
    class MainApp
    {
        public static void Main()
        {
            LocacaoDeVeiculo veiculoAlugado = new LocacaoDeVeiculo(new Sedan4Portas(), new Alcool());
            veiculoAlugado.Rodar();

            veiculoAlugado = new LocacaoDeVeiculo(new CaminhaoBasculante(), new Diesel());
            veiculoAlugado.Rodar();

            //NÃO PODE!
            veiculoAlugado = new LocacaoDeVeiculo(new CaminhaoBasculante(), new Alcool());
            veiculoAlugado.Rodar();
            
            //NÃO PODE!
            veiculoAlugado = new LocacaoDeVeiculo(new Sedan4Portas(), new Diesel());
            veiculoAlugado.Rodar();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>

    abstract class Combustivel
    {
    }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>

    abstract class Veiculo
    {
        public abstract void Consome(Combustivel h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>

    class Alcool : Combustivel
    {
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>

    class Sedan4Portas : Veiculo
    {
        public override void Consome(Combustivel h)
        {
            Console.WriteLine(this.GetType().Name +
              " consome " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>

    class Diesel : Combustivel
    {
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>

    class CaminhaoBasculante : Veiculo
    {
        public override void Consome(Combustivel h)
        {
            Console.WriteLine(this.GetType().Name +
              " consome " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>

    class LocacaoDeVeiculo
    {
        private Combustivel _combustivel;
        private Veiculo _veiculo;
        
        public LocacaoDeVeiculo(Veiculo veiculo, Combustivel combustivel)
        {
            _combustivel = combustivel;
            _veiculo = veiculo;
        }

        public void Rodar()
        {
            _veiculo.Consome(_combustivel);
        }
    }
}
