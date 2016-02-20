namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons.ModelTemplates
{
	public class JavaModelTemplate : ModelTemplateBase
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
			return @"{1}";
		}

		public override string GetClassTemplate()
		{
			return @"{1}";
		}
	}
}