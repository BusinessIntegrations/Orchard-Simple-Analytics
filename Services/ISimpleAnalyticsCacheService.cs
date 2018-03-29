#region Using
using Orchard;
#endregion

namespace Lombiq.SimpleAnalytics.Services {
    public interface ISimpleAnalyticsCacheService : IDependency {
        #region Methods
        CacheHelper GetScript();
        #endregion
    }
}
