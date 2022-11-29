import { Injectable } from '@nestjs/common';
import { IMessageService } from '../interfaces/message_service.interface';
import { SendEmailDto } from '../dto/send.email.dto';
import { ConfigService } from '@nestjs/config';
import * as SendGrid from '@sendgrid/mail';

@Injectable()
export class SendgridService implements IMessageService {
  constructor(private readonly configService: ConfigService) {
    SendGrid.setApiKey(this.configService.get<string>('SEND_GRID_KEY'));
  }

  async sendEmail(mail: SendEmailDto): Promise<void> {
    await SendGrid.send({
      from: 'josedaza9@gmail.com',
      subject: mail.Title,
      to: mail.Destination,
      text: mail.Body,
    });
    console.log('Email sent successfully to ' + mail.Destination);
  }
}
