using System;

namespace AbstractFactoryPattern
{
    //Ürünler için olan soyut tanımlamalar
    public abstract class Connection
    {
        public abstract bool Connect();
        public abstract bool Disconnect();
        public abstract string State
        {
            get;
        }
    }

    public abstract class Command
    {
        public abstract void Execute(string query);
    }

    //Connection abstract'ını concrete etmiş oluyoruz. Ürün tanımlamış oluyoruz.
    public class Db2Connection : Connection
    {
        public override string State
        {
            get { return "Open"; }
        }

        public override bool Connect()
        {
            Console.WriteLine("Db2 bağlantısı açılacak.");
            return true;
        }

        public override bool Disconnect()
        {
            Console.WriteLine("Db2 bağlantısı kapatılacak.");
            return true;
        }
    }

    //Diğer bir ürün tanımlaması. 
    public class InterbaseConnection : Connection
    {
        public override string State
        {
            get { return "Open"; }
        }

        public override bool Connect()
        {
            Console.WriteLine("Interbase bağlantısı açılacak.");
            return true;
        }

        public override bool Disconnect()
        {
            Console.WriteLine("Interbase bağlantısı kapatılacak");
            return true;
        }
    }

    public class Db2Command : Command
    {
        public override void Execute(string query)
        {
            Console.WriteLine("Db2 sorgusu çalıştırılır.");
        }
    }

    public class InterbaseCommand : Command
    {
        public override void Execute(string query)
        {
            Console.WriteLine("Interbase sorgusu çalıştırılır.");
        }
    }
    //Buraya kadar ürünlerimizi ve soyut sınıflarımızı tasarladık.
    //Fabrika lazım

    public abstract class DatabaseFactory
    {
        public abstract Connection CreateConnection();
        public abstract Command CreateCommand();
    }

    public class Db2Factory : DatabaseFactory //Db2Factory kendi tipindeki ürünlerle ilgilenmekte.
    {
        public override Connection CreateConnection()
        {
            return new Db2Connection();
        }

        public override Command CreateCommand()
        {
            return new Db2Command();
        }
    }

    public class InterbaseFactory : DatabaseFactory
    {
        public override Command CreateCommand()
        {
            return new InterbaseCommand();
        }

        public override Connection CreateConnection()
        {
            return new InterbaseConnection();
        }
    }

    //İstemcinin fabrika seçimini yapacağı sınıfı tasarlayacağız.
    public class Factory
    {
        private DatabaseFactory _databaseFactory;
        private Connection _connection;
        private Command _command;

        public Factory(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _connection = _databaseFactory.CreateConnection();
            _command = _databaseFactory.CreateCommand();
        }

        public void Start()
        {
            _connection.Connect();
            if (_connection.State == "Open")
                _command.Execute("Select ...");
        }
    }

}
