namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons.ModelTemplates
{
    public class CSharpModelTemplate : ModelTemplateBase
    {
        public override string GetPropertyTemplate()
        {
            return @"
public const string {0:U} = ""{0}"";
        public {1} {2}
        {{
            get
            {{
                    return GetValue<{1}>({0:U});
            }}
            set
            {{
                SetValue({0:U}, value);
            }}
        }}
";
        }

        public override string GetHeaderTemplate()
        {
            return @"{0}";
        }

        public override string GetClassTemplate()
        {
            return @"
{0}

namespace {1}
{{
    {2} class {3} {4}
    {{
        public {3}() : base(""{5}"")
        {{
        }}
        {6}

        protected override IModel GetInstance()
        {{
            return new {3}();
        }}
    }}
}}
";
        }
    }
}