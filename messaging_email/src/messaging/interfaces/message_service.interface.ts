import { SendEmailDto } from '../dto/send.email.dto';

export interface IMessageService {
  sendEmail(mail: SendEmailDto): Promise<void>;
}
