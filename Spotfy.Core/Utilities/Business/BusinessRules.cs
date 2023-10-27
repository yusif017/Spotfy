using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Core.Utilities.Results.Concrete.ErrorResults;
using Spotfy.Core.Utilities.Results.Concrete.SuccessResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Check(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
