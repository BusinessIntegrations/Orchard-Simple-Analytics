namespace Lombiq.SimpleAnalytics.Services {
    public interface ICacheModel {
        #region Properties
        bool IncludeOnAdmin { get; }
        string Script { get; }
        #endregion
    }
}
