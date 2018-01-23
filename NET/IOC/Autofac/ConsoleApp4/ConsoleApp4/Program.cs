using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Demo1
            Console.WriteLine("==========> Demo1 <==============");
            var builder = new ContainerBuilder();

            builder.RegisterType<DataSourceManager>();

            builder.RegisterType<Sqlserver>().As<IDataSource>();

            using (var container = builder.Build())
            {
                var manager = container.Resolve<DataSourceManager>();
                Console.WriteLine(manager.GetData());
            }
            var builder2 = new ContainerBuilder();

            //builder2.RegisterType<DataSourceManager>();

            builder2.RegisterType<Sqlserver>().As<IDataSource>();
            using (var container = builder2.Build())
            {
                var manager = container.Resolve<IDataSource>();
                Console.WriteLine(manager.GetData());
            }

            var builder3 = new ContainerBuilder();
            builder3.RegisterType<Sqlserver>().Named<IDataSource>("SqlServer");
            builder3.RegisterType<Oracle>().Named<IDataSource>("Oracel");
            using (var container = builder3.Build())
            {
                var manager = container.ResolveNamed<IDataSource>("Oracel");
                Console.WriteLine(manager.GetData());               
            }

            var builder4 = new ContainerBuilder();
            builder4.RegisterType<DataSourceManager>();
            builder4.RegisterType<Sqlserver>().As<IDataSource>();

            //builder4.RegisterType<Sqlserver>().Named<IDataSource>("SqlServer");
           // builder4.RegisterType<Oracle>().Named<IDataSource>("Oracel");

            using (var container = builder4.Build())
            {
                var manager = container.Resolve<DataSourceManager>(new NamedParameter("name", "AAAAAA"),new NamedParameter("ds",new Oracle()));
                Console.WriteLine(manager.GetData());
            }
            #endregion

            #region Demo2
            Console.WriteLine("==========> Demo2 <==============");
            var builder5 = new ContainerBuilder();

            builder5.RegisterGeneric(typeof(Dal<>)).As(typeof(Idal<>)) .InstancePerDependency();

            builder5.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            builder5.Register(c => new PersionBll((IRepository<Persion>)c.Resolve(typeof(IRepository<Persion>))));

            builder5.Register(c => new CustomBll((IRepository<Custom>)c.Resolve(typeof(IRepository<Custom>))));

            //var container = builder.Build()教程里都是使用这行代码，
            //我本地测试需要加入ContainerBuildOptions枚举选项。
            using (var container = builder5.Build(ContainerBuildOptions.None))
            {

                // var repository= container.Resolve(typeof(IRepository<Persion>),new TypedParameter());
                // IRepository<Persion> _repository = repository as Repository<Persion>;
                // var m = new PersionBll(_repository);
                Persion p = new Persion();
                p.Name = "小人";
                p.Age = 27;
                var m = container.Resolve<PersionBll>();
                m.Insert(p);
                Custom c = new Custom();
                c.CustomName = "小小";
                c.CustomID = 10;
                var cc = container.Resolve<CustomBll>();
                cc.Update(c);
            }
            #endregion

            Console.ReadLine();
        }
    }

#region Demo1
    /// <summary>
    /// 数据源操作接口
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        string GetData();
    }

    /// <summary>
    /// SQLSERVER数据库
    /// </summary>
    class Sqlserver : IDataSource
    {
        public string GetData()
        {
            return "通过SQLSERVER获取数据";
        }
    }

    /// <summary>
    /// ORACLE数据库
    /// </summary>
    public class Oracle : IDataSource
    {
        public string GetData()
        {
            return "通过Oracle获取数据";
        }
    }

    /// <summary> 
    /// 数据源管理类
    /// </summary
    public class DataSourceManager
    {
        string Name;
        IDataSource _ds;
        /// <summary>
        /// 根据传入的类型动态创建对象
        /// </summary>
        /// <param name="ds"></param>
        public DataSourceManager(IDataSource ds)
        {
            Name = "Default";
            _ds = ds;
        }

        public DataSourceManager(string name, IDataSource ds)
        {
            _ds = ds;
            Name = name;
        }

        public string GetData()
        {
            return Name + "：" + _ds.GetData();
        }
    }

    #endregion

    #region Demo2

    public class Persion
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Custom
    {
        public string CustomName { get; set; }
        public int CustomID { get; set; }
    }

    public interface Idal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class Dal<T> : Idal<T> where T : class
    {

        #region Idal<T> Members

        public void Insert(T entity)
        {
            Console.WriteLine("您添加了一个："+ entity.GetType().FullName);
        }

        public void Update(T entity)
        {

            Console.WriteLine("您更新一个:"+ entity.GetType().FullName);
        }

        public void Delete(T entity)
        {
            Console.WriteLine("您删除了一个："+ entity.GetType().FullName);
        }

        #endregion
    }


    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private Idal<T> _dal;

        public Repository(Idal<T> dal)
        {
            _dal = dal;
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            _dal.Insert(entity);
        }

        public void Update(T entity)
        {
            _dal.Update(entity);
        }

        public void Delete(T entity)
        {
            _dal.Delete(entity);
        }

        #endregion
    }

    public interface IDependency
    {
    }

    public class CustomBll : IDependency
    {
        private readonly IRepository<Custom> _repository;
        public CustomBll(IRepository<Custom> repository)
        {
            _repository = repository;
        }

        public void Insert(Custom c)
        {
            _repository.Insert(c);
        }

        public void Update(Custom c)
        {
            _repository.Update(c);
        }

        public void Delete(Custom c)
        {
            _repository.Delete(c);
        }
    }

    public class PersionBll : IDependency
    {
        private readonly IRepository<Persion> _repository;

        public PersionBll(IRepository<Persion> repository)
        {
            _repository = repository;
        }

        public void Insert(Persion p)
        {
            _repository.Insert(p);
        }

        public void Update(Persion p)
        {
            _repository.Update(p);
        }

        public void Delete(Persion p)
        {
            _repository.Delete(p);
        }
    }

    #endregion

}
