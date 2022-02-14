//using System;

//namespace Factory
//{
//    class MainApp
//    {
//        public static void Main()
//        {
//            VeiculoFactory carroDePasseio = new CarroDePasseioFactory();
//            LocacaoDeVeiculo veiculoAlugado = new LocacaoDeVeiculo(carroDePasseio);
//            veiculoAlugado.Rodar();

//            VeiculoFactory caminhao = new CaminhaoFactory();
//            veiculoAlugado = new LocacaoDeVeiculo(caminhao);
//            veiculoAlugado.Rodar();

//            Console.ReadKey();
//        }
//    }


//    /// <summary>
//    /// The 'AbstractFactory' abstract class
//    /// </summary>

//    abstract class VeiculoFactory
//    {
//        public abstract Combustivel CreateCombustivel();
//        public abstract Veiculo CreateVeiculo();
//    }

//    /// <summary>
//    /// The 'ConcreteFactory1' class
//    /// </summary>

//    class CarroDePasseioFactory : VeiculoFactory
//    {
//        public override Combustivel CreateCombustivel()
//        {
//            return new Alcool();
//        }
//        public override Veiculo CreateVeiculo()
//        {
//            return new Sedan4Portas();
//        }
//    }

//    /// <summary>
//    /// The 'ConcreteFactory2' class
//    /// </summary>

//    class CaminhaoFactory : VeiculoFactory
//    {
//        public override Combustivel CreateCombustivel()
//        {
//            return new Diesel();
//        }
//        public override Veiculo CreateVeiculo()
//        {
//            return new CaminhaoBasculante();
//        }
//    }

//    /// <summary>
//    /// The 'AbstractProductA' abstract class
//    /// </summary>

//    abstract class Combustivel
//    {
//    }

//    /// <summary>
//    /// The 'AbstractProductB' abstract class
//    /// </summary>

//    abstract class Veiculo
//    {
//        public abstract void Consome(Combustivel h);
//    }

//    /// <summary>
//    /// The 'ProductA1' class
//    /// </summary>

//    class Alcool : Combustivel
//    {
//    }

//    /// <summary>
//    /// The 'ProductB1' class
//    /// </summary>

//    class Sedan4Portas : Veiculo
//    {
//        public override void Consome(Combustivel h)
//        {
//            Console.WriteLine(this.GetType().Name +
//              " consome " + h.GetType().Name);
//        }
//    }

//    /// <summary>
//    /// The 'ProductA2' class
//    /// </summary>

//    class Diesel : Combustivel
//    {
//    }

//    /// <summary>
//    /// The 'ProductB2' class
//    /// </summary>

//    class CaminhaoBasculante : Veiculo
//    {
//        public override void Consome(Combustivel h)
//        {
//            Console.WriteLine(this.GetType().Name +
//              " consome " + h.GetType().Name);
//        }
//    }

//    /// <summary>
//    /// The 'Client' class 
//    /// </summary>

//    class LocacaoDeVeiculo
//    {
//        private Combustivel _combustivel;
//        private Veiculo _veiculo;

//        public LocacaoDeVeiculo(VeiculoFactory factory)
//        {
//            _veiculo = factory.CreateVeiculo();
//            _combustivel = factory.CreateCombustivel();
//        }

//        public void Rodar()
//        {
//            _veiculo.Consome(_combustivel);
//        }
//    }
//}
