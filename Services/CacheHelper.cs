namespace Lombiq.SimpleAnalytics.Services {
    public class CacheHelper {
        public CacheHelper(string script, bool includeInAdmin) {
            Script = script;
            IncludeInAdmin = includeInAdmin;
        }

        #region Properties
        public bool IncludeInAdmin { get; }
        public string Script { get; }
        #endregion
    }
}
