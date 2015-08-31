using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Con_Air.Common
{
    /// <summary>
    /// ?? 
    /// </summary>

    public class CodeStorageModel : Model
    {
        public CodeStorageModel() : base("CodeStorage")
        {
        }

        public const string CODEBLOB = "codeblob";
        public string Codeblob
        {
            get
            {
                return GetValue<string>(CODEBLOB);
            }
            set
            {
                SetValue(CODEBLOB, value);
            }
        }

        protected override IModel GetInstance()
        {
            return new CodeStorageModel();
        }
    }
}