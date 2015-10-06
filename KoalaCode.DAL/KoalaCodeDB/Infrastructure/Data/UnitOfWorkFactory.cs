namespace KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {

        public UnitOfWorkFactory()
        {
            UnitOfWork = new UnitOfWork();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        public UnitOfWork UnitOfWork { get; private set; }
    }
}