import { Controller } from '@nestjs/common';
import { MessagingService } from './messaging.service';
import { EventPattern } from '@nestjs/microservices';
import { SendEmailDto } from './dto/send.email.dto';

@Controller()
export class MessagingController {
  constructor(private readonly messagingService: MessagingService) {}

  @EventPattern()
  async sendEmail(mail: SendEmailDto): Promise<void> {
    await this.messagingService.sendEmail(mail);
  }
}
