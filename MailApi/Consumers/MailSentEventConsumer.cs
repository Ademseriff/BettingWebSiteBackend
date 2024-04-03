using MailApi.DTOs;
using MailApi.Services.Abstractions;
using MassTransit;
using Shared.Events;

namespace MailApi.Consumers
{
    public class MailSentEventConsumer : IConsumer<MailSentEvent>
    {
        private readonly IMailService mailService;

        public MailSentEventConsumer(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public async Task Consume(ConsumeContext<MailSentEvent> context)
        {
            MailDto mailDto = new MailDto();
            mailDto.Subject = "DUR BET SİSTEM MESAJI";

            if (context.Message.EMail != null) {
                mailDto.Reciver = context.Message.EMail;
            }
           
            if (context.Message.State == Shared.Enums.MailEnum.CustomerAdd)
            {
                mailDto.Body = "Kullanıcı profiliniz oluşturuldu. Teşekkür ederiz.. --Durbet--";
                await mailService.SendMail(mailDto);
            }

            else if (context.Message.State == Shared.Enums.MailEnum.MoneyAdd)
            {
                mailDto.Body = $"Hesabınıza {context.Message.Price} $ para girişi olmuştur --Durbet--";
                await mailService.SendMail(mailDto);
            }
            else if (context.Message.State == Shared.Enums.MailEnum.MoneyDiscard)
            {
                mailDto.Body = $"Kuponunuz oynandı Maksimum kazanç :{context.Message.Price} $ --Durbet-- ";
                await mailService.SendMail(mailDto);
            }

        }
    }
}
