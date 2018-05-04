namespace Lombiq.SimpleAnalytics.Services {
    public class CacheModel : ICacheModel {
        public CacheModel(string script, bool includeOnAdmin) {
            Script = $"<script type=\"text/javascript\">{script}</script>";
            ;
            IncludeOnAdmin = includeOnAdmin;
        }

        #region ICacheModel Members
        public bool IncludeOnAdmin { get; }
        public string Script { get; }
        #endregion
    }
}
