using System;

namespace Factory
{
    class MainApp
    {
        public static void Main()
        {
            LocacaoDeVeiculo veiculoAlugado = new LocacaoDeVeiculo(new CarroDePasseioFactory());
            veiculoAlugado.Rodar();

            veiculoAlugado = new LocacaoDeVeiculo(new CaminhaoFactory());
            veiculoAlugado.Rodar();

            ////NÃO PODE!
            //veiculoAlugado = new LocacaoDeVeiculo(new Sedan4Portas(), new Diesel());
            //veiculoAlugado.Rodar();

            ////NÃO PODE!
            //veiculoAlugado = new LocacaoDeVeiculo(new CaminhaoBasculante(), new Alcool());
            //veiculoAlugado.Rodar();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// A classe "Abstract Factory"
    /// </summary>
    abstract class VeiculoFactory
    {
        public abstract Veiculo CreateVeiculo();
        public abstract Combustivel CreateCombustivel();
    }


    /// <summary>
    /// Fábrica concreta
    /// </summary>
    class CarroDePasseioFactory : VeiculoFactory
    {
        public override Combustivel CreateCombustivel()
        {
            return new Alcool();
        }

        public override Veiculo CreateVeiculo()
        {
            return new Sedan4Portas();
        }
    }

    /// <summary>
    /// Fábrica concreta
    /// </summary>
    class CaminhaoFactory : VeiculoFactory
    {
        public override Combustivel CreateCombustivel()
        {
            return new Diesel();
        }

        public override Veiculo CreateVeiculo()
        {
            return new CaminhaoBasculante();
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
        
        public LocacaoDeVeiculo(VeiculoFactory veiculoFactory)
        {
            _combustivel = veiculoFactory.CreateCombustivel();
            _veiculo = veiculoFactory.CreateVeiculo();
        }

        public void Rodar()
        {
            _veiculo.Consome(_combustivel);
        }
    }
}
