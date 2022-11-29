import { Injectable } from '@nestjs/common';
import { SendgridService } from './sendgrid/sendgrid.service';
import { SendEmailDto } from './dto/send.email.dto';

@Injectable()
export class MessagingService {
  constructor(private readonly messagingService: SendgridService) {}

  async sendEmail(mail: SendEmailDto): Promise<void> {
    await this.messagingService.sendEmail(mail);
  }
}
