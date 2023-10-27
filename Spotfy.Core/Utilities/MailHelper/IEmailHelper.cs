﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Core.Utilities.MailHelper
{
    public interface IEmailHelper
    {
        bool SendEmail(string mailAddress, string token, bool bodyHtml);
    }
}
