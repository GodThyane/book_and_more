import { Module } from '@nestjs/common';
import { MessagingService } from './messaging.service';
import { MessagingController } from './messaging.controller';
import { SendgridService } from './sendgrid/sendgrid.service';

@Module({
  controllers: [MessagingController],
  providers: [MessagingService, SendgridService],
})
export class MessagingModule {}
