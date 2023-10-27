
using MassTransit;
using Spotfy.Core.Utilities.MailHelper;
using Spotfy.Entities.ShareModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Business.Consumer
{
    public class ReceiveEmailConsumer : IConsumer<SendEmailCommand>
    {
        private readonly IEmailHelper _emailHelper;

        public ReceiveEmailConsumer(IEmailHelper emailHelper)
        {
            _emailHelper = emailHelper;
        }

        public async Task Consume(ConsumeContext<SendEmailCommand> context)
        {
            _emailHelper.SendEmail(context.Message.Email, context.Message.Token, true);
        }
    }
}
