using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.BusEvents.Handlers
{
    public interface IPointsHandler : IGlobalSubscriber
    {
        void AddScore(float count);
        void LoseHP(float count);
    }
}
