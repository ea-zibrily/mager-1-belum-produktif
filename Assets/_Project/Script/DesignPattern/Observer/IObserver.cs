using BelumProduktif.Enum;

namespace BelumProduktif.DesignPattern.Observer
{
    public interface IObserver
    {
        public void AddNotify(GameConditionEnum gameConditionEnum);
    }
}