using CodeFirstStoreFunctions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStringSplitApplication
{
    public partial class TestModel
    {
        public DbSet<StringSplitResult> StringSplitResults { get; set; }

        [DbFunction(nameof(TestModel), nameof(String_split))]
        [DbFunctionDetails(IsBuiltIn = true)]
        public IQueryable<StringSplitResult> String_split(string source, string separator)
        {
            var sourceParameter = new ObjectParameter("Source", source);
            var separatorParameter = new ObjectParameter("Separator", separator);

            return ((IObjectContextAdapter)this).ObjectContext
                .CreateQuery<StringSplitResult>(
                    string.Format("[{0}].{1}", GetType().Name, "STRING_SPLIT(@Source, @Separator)"),
                    sourceParameter, separatorParameter);
        }
    }
}
